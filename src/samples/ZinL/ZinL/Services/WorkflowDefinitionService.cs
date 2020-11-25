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


        public WorkflowDefinitionService(
            //IServiceProvider serviceProvider,
           ElsaContext elsaDBContext,
           IWorkflowDefinitionStore workflowDefinitionStore,
           IWorkflowInstanceStore workflowInstanceStore,
           IWorkflowPublisher publisher,
           IWorkflowSerializer serializer,
           AutoMapper.IMapper mapper)
        {
            //_elsaDBContext = (ElsaDBContext)serviceProvider.GetService<ElsaDBContext>();
            _elsaDBContext = (ElsaDBContext)elsaDBContext;
            _workflowDefinitionStore = workflowDefinitionStore;
            _workflowInstanceStore = workflowInstanceStore;
            _publisher = publisher;
            _serializer = serializer;
            _mapper = mapper;
        }
      
        public async Task<List<WorkflowDefinitionListResponse>> GetListDefinitionAsync(CancellationToken cancellationToken)
        {
            var workflows = await _workflowDefinitionStore.ListAsync(
                VersionOptions.LatestOrPublished, cancellationToken);

            return _mapper.Map<List<WorkflowDefinitionListResponse>>(workflows);
        }

        public async Task<WorkflowDefinitionDetailResponse> GetDetailDefinitionAsync(string id, CancellationToken cancellationToken)
        {
            var workflow = await _workflowDefinitionStore.GetByIdAsync(id, 
               VersionOptions.LatestOrPublished, cancellationToken);

            return _mapper.Map<WorkflowDefinitionDetailResponse>(workflow);
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
