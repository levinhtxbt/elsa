using Elsa.Dashboard.Areas.Elsa.ViewModels;
using Elsa.Models;
using Elsa.Persistence;
using Elsa.Serialization;
using Elsa.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Domain;
using ZinL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using Microsoft.Extensions.DependencyInjection;
using Elsa.Persistence.EntityFrameworkCore.DbContexts;
using AutoMapper;
using Elsa.WorkflowDesigner.Models;
using Elsa.Serialization.Formatters;
using Elsa.Dashboard.Models;
using SS.Lib.Http;
using Microsoft.AspNetCore.Http;
using ZinL.Models.Common;
using Elsa.Dashboard.Options;

namespace ZinL.Services
{
    public class WorkflowDefinitionService : IWorkflowDefinitionService
    {
        private readonly ElsaDBContext _elsaDBContext;
        private readonly IWorkflowDefinitionStore _workflowDefinitionStore;
        private readonly IWorkflowInstanceStore _workflowInstanceStore;
        private readonly IWorkflowPublisher _publisher;
        private readonly IWorkflowSerializer _serializer;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IOptions<ElsaDashboardOptions> _options;


        public WorkflowDefinitionService(
           ElsaContext elsaDBContext,
           IWorkflowDefinitionStore workflowDefinitionStore,
           IWorkflowInstanceStore workflowInstanceStore,
           IWorkflowPublisher publisher,
           IWorkflowSerializer serializer,
           AutoMapper.IMapper mapper,
           IOptions<ElsaDashboardOptions> options)
        {
            _elsaDBContext = (ElsaDBContext)elsaDBContext;
            _workflowDefinitionStore = workflowDefinitionStore;
            _workflowInstanceStore = workflowInstanceStore;
            _publisher = publisher;
            _serializer = serializer;
            _mapper = mapper;
            _options = options;
        }
      
        public async Task<List<WorkflowDefinitionListResponse>> GetListDefinitionAsync(CancellationToken cancellationToken)
        {
            var workflows = await _workflowDefinitionStore.ListAsync(
                VersionOptions.LatestOrPublished, cancellationToken);

            if (workflows == null)
            {
                throw new ErrorException(StatusCodes.Status404NotFound, "Workflow definition is not found.");
            }

            var workflowModels = new List<WorkflowDefinitionListItemModel>();
            foreach (var workflow in workflows)
            {
                var workflowModel = await CreateWorkflowDefinitionListItemModelAsync(workflow, cancellationToken);
                workflowModels.Add(workflowModel);
            }

            var groups = workflowModels.GroupBy(x => x.WorkflowDefinition.DefinitionId);
            var model = new WorkflowDefinitionListViewModel
            {
                WorkflowDefinitions = groups.ToList()
            };

            //var result  = _mapper.Map<>

            return _mapper.Map<List<WorkflowDefinitionListResponse>>(workflows);
        }

        public async Task<WorkflowDefinitionDetailResponse> GetDetailDefinitionAsync(string id, CancellationToken cancellationToken)
        {
            var workflowDefinition = await _publisher.GetDraftAsync(id, cancellationToken);

            if (workflowDefinition == null)
                throw new ErrorException(StatusCodes.Status404NotFound, $"Can't not found workflow definition with {id}");

            var workflowModel = new WorkflowModel
            {
                Activities = workflowDefinition.Activities.Select(x => new ActivityModel(x)).ToList(),
                Connections = workflowDefinition.Connections.Select(x => new ConnectionModel(x)).ToList()
            };

            var model = new WorkflowDefinitionEditModel
            {
                Id = workflowDefinition.DefinitionId,
                Name = workflowDefinition.Name,
                Json = _serializer.Serialize(workflowModel, JsonTokenFormatter.FormatName),
                Description = workflowDefinition.Description,
                IsSingleton = workflowDefinition.IsSingleton,
                IsDisabled = workflowDefinition.IsDisabled,
                ActivityDefinitions = _options.Value.ActivityDefinitions.ToArray(),
                WorkflowModel = workflowModel
            };

            return _mapper.Map<WorkflowDefinitionDetailResponse>(model);
        }


        private async Task<WorkflowDefinitionListItemModel> CreateWorkflowDefinitionListItemModelAsync(
           WorkflowDefinitionVersion workflowDefinition, CancellationToken cancellationToken)
        {
            var instances = await _workflowInstanceStore
                .ListByDefinitionAsync(workflowDefinition.DefinitionId, cancellationToken)
                .ConfigureAwait(false);

            return new WorkflowDefinitionListItemModel
            {
                WorkflowDefinition = workflowDefinition,
                AbortedCount = instances.Count(x => x.Status == WorkflowStatus.Aborted),
                FaultedCount = instances.Count(x => x.Status == WorkflowStatus.Faulted),
                FinishedCount = instances.Count(x => x.Status == WorkflowStatus.Finished),

                ExecutingCount = instances.Count(x => x.Status == WorkflowStatus.Executing),
            };
        }

        public async Task<WorkflowDefinitionCreateResponse> CreateDefinitionAsunc(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        {
            var workflow = new WorkflowDefinitionVersion();
            var postedWorkflow = _serializer.Deserialize<WorkflowModel>(model.Json, JsonTokenFormatter.FormatName);

            workflow.Activities = postedWorkflow.Activities
                .Select(x => new ActivityDefinition(x.Id, x.Type, x.State, x.Left, x.Top))
                .ToList();

            workflow.Connections = postedWorkflow.Connections.Select(
                x => new ConnectionDefinition(x.SourceActivityId, x.DestinationActivityId, x.Outcome)).ToList();

            workflow.Description = model.Description;
            workflow.Name = model.Name;
            workflow.IsDisabled = model.IsDisabled;
            workflow.IsSingleton = model.IsSingleton;

            var publish = model.SubmitAction == "publish";

            if (publish)
            {
                workflow = await _publisher.PublishAsync(workflow, cancellationToken);
            }
            else
            {
                workflow = await _publisher.SaveDraftAsync(workflow, cancellationToken);
            }

            return _mapper.Map<WorkflowDefinitionCreateResponse>(workflow);
        }

        public async Task<WorkflowDefinitionEditResponse> EditDefinitionAsunc(string id, WorkflowDefinitionEditModel request, CancellationToken cancellationToken)
        {
            var workflow = await _workflowDefinitionStore.GetByIdAsync(id, VersionOptions.Latest, cancellationToken);

            if (workflow == null)
                throw new ErrorException(StatusCodes.Status404NotFound, $"Can't not found workflow definition with {id}");

            var postedWorkflow = _serializer.Deserialize<WorkflowModel>(request.Json, JsonTokenFormatter.FormatName);

            workflow.Activities = postedWorkflow.Activities
                .Select(x => new ActivityDefinition(x.Id, x.Type, x.State, x.Left, x.Top))
                .ToList();

            workflow.Connections = postedWorkflow.Connections.Select(
                x => new ConnectionDefinition(x.SourceActivityId, x.DestinationActivityId, x.Outcome)).ToList();

            workflow.Description = request.Description;
            workflow.Name = request.Name;
            workflow.IsDisabled = request.IsDisabled;
            workflow.IsSingleton = request.IsSingleton;

            var publish = request.SubmitAction == Constants.PublishVersion;

            if (publish)
            {
                workflow = await _publisher.PublishAsync(workflow, cancellationToken);
            }
            else
            {
                workflow = await _publisher.SaveDraftAsync(workflow, cancellationToken);
            }

            return _mapper.Map<WorkflowDefinitionEditResponse>(workflow);
        }

        public async Task<string> DeleteDefinitionAsunc(string id, CancellationToken cancellationToken)
        {
            await _workflowDefinitionStore.DeleteAsync(id, cancellationToken);

            return id;
        }
    }
}
