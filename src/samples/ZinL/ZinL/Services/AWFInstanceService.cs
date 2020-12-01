using Elsa.Dashboard.Areas.Elsa.ViewModels;
using Elsa.Dashboard.Options;
using Elsa.Models;
using Elsa.Persistence;
using Elsa.WorkflowDesigner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SS.Lib.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models.Instance;

namespace ZinL.Services
{
    public class AWFInstanceService : IAWFInstanceService
    {
        private readonly IWorkflowInstanceStore _workflowInstanceStore;
        private readonly IWorkflowDefinitionStore _workflowDefinitionStore;
        private readonly IOptions<ElsaDashboardOptions> _options;
        private readonly AutoMapper.IMapper _mapper;

        public AWFInstanceService(
            IWorkflowInstanceStore workflowInstanceStore,
            IWorkflowDefinitionStore workflowDefinitionStore,
            IOptions<ElsaDashboardOptions> options,
            AutoMapper.IMapper mapper)
        {
            _workflowInstanceStore = workflowInstanceStore;
            _workflowDefinitionStore = workflowDefinitionStore;
            _options = options;
            _mapper = mapper;
        }
       
        public async Task<WorkflowInstanceListViewModel> GetListInstanceAsync(AWFInstanceListRequest request, CancellationToken cancellationToken)
        {
            var definition = await _workflowDefinitionStore.GetByIdAsync(
               request.DefinitionId,
               VersionOptions.Latest,
               cancellationToken
           );

            if (definition == null)
                throw new ErrorException(StatusCodes.Status404NotFound, $"Can found definition with definitionId: {request.DefinitionId}");

            var instances = await _workflowInstanceStore
                .ListByStatusAsync(request.DefinitionId, request.Status, cancellationToken);

            if (instances == null)
                throw new ErrorException(StatusCodes.Status404NotFound, $"Can found instance with definitionId: {request.DefinitionId}");

            var model = new WorkflowInstanceListViewModel
            {
                WorkflowDefinition = definition,
                //ReturnUrl = Url.Action("Index", new { request.DefinitionId, request.Status }),
                WorkflowInstances = instances.Select(
                        x => new WorkflowInstanceListItemModel
                        {
                            WorkflowInstance = x
                        }
                    )
                    .ToList()
            };

            return model;
        }

       
        public async Task<AWFInstanceDetailResponse> GetDetailInstanceAsync(string id, string returnUrl, CancellationToken cancellationToken)
        {
            var instance = await _workflowInstanceStore.GetByIdAsync(id, cancellationToken);

            if (instance == null)
                throw new ErrorException(StatusCodes.Status404NotFound, $"Can found workflow instance with definitionId: {id}");

            var definition = await _workflowDefinitionStore.GetByIdAsync(
                instance.DefinitionId,
                VersionOptions.SpecificVersion(instance.Version),
                cancellationToken
            );

            var workflow = new WorkflowModel
            {
                Activities = definition.Activities.Select(x => CreateActivityModel(x, instance)).ToList(),
                Connections = definition.Connections.Select(x => new ConnectionModel(x)).ToList()
            };

            var model = new AWFInstanceDetailResponse
            {
                WorkflowInstance = instance,
                WorkflowDefinition = definition,
                WorkflowModel = workflow,
                ActivityDefinitions = _options.Value.ActivityDefinitions.ToArray(),
                ReturnUrl = returnUrl
            };
            //var model = new WorkflowInstanceDetailsModel(
            //    instance,
            //    definition,
            //    workflow,
            //    _options.Value.ActivityDefinitions,
            //    returnUrl);

            //return _mapper.Map<AWFInstanceDetailResponse>(model);
            return model;
        }

        public async Task<string> DeleteInstanceAsync(string id, CancellationToken cancellationToken)
        {
            var instance = await _workflowInstanceStore.GetByIdAsync(id, cancellationToken);

            if (instance == null)
                throw new ErrorException(StatusCodes.Status404NotFound, $"Can found workflow instance with definitionId: {id}");

            await _workflowInstanceStore.DeleteAsync(id, cancellationToken);

            return id;
        }


        //public Task<AWFInstanceCreateResponse> CreateInstanceAsync(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
        private ActivityModel CreateActivityModel(
            ActivityDefinition activityDefinition,
            WorkflowInstance workflowInstance)
        {
            var isBlocking = workflowInstance.BlockingActivities.Any(x => x.ActivityId == activityDefinition.Id);
            var logEntry = workflowInstance.ExecutionLog.OrderByDescending(x => x.Timestamp)
                .FirstOrDefault(x => x.ActivityId == activityDefinition.Id);
            var isExecuted = logEntry != null;
            var isFaulted = logEntry?.Faulted ?? false;
            var message = default(ActivityMessageModel);

            if (isFaulted)
                message = new ActivityMessageModel("Faulted", logEntry.Message);
            else if (isBlocking)
                message = new ActivityMessageModel(
                    "Blocking",
                    "This activity is blocking workflow execution until the appropriate event is triggered.");
            else if (isExecuted)
                message = new ActivityMessageModel("Executed", logEntry.Message);

            return new ActivityModel(activityDefinition, isBlocking, isExecuted, isFaulted, message);
        }
    }
}
