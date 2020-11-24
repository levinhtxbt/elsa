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

namespace ZinL.Services
{
    public class WorkflowDefinitionService : IWorkflowDefinitionService
    {
        private readonly ElsaDBContext _elsaDBContext;
        private readonly IWorkflowDefinitionStore _workflowDefinitionStore;
        private readonly IWorkflowInstanceStore _workflowInstanceStore;
        private readonly IWorkflowPublisher _publisher;
        private readonly IWorkflowSerializer _serializer;


        public WorkflowDefinitionService(
            //IServiceProvider serviceProvider,
           ElsaContext elsaDBContext,
           IWorkflowDefinitionStore workflowDefinitionStore,
           IWorkflowInstanceStore workflowInstanceStore,
           IWorkflowPublisher publisher,
           IWorkflowSerializer serializer)
        {
            //_elsaDBContext = (ElsaDBContext)serviceProvider.GetService<ElsaDBContext>();
            _elsaDBContext = (ElsaDBContext)elsaDBContext;
            _workflowDefinitionStore = workflowDefinitionStore;
            _workflowInstanceStore = workflowInstanceStore;
            _publisher = publisher;
            _serializer = serializer;
        }

        public async Task<List<WorkflowDefinitionListResponse>> GetListDefinitionAsync(CancellationToken cancellationToken)
        {
            var workflows = await _workflowDefinitionStore.ListAsync(
                VersionOptions.LatestOrPublished, cancellationToken);

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

            return new List<WorkflowDefinitionListResponse>();
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
    }
}
