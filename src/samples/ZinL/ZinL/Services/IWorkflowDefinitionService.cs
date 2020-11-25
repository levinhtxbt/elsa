using Elsa.Dashboard.Areas.Elsa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models;

namespace ZinL.Services
{
    public interface IWorkflowDefinitionService
    {
        Task<List<WorkflowDefinitionListResponse>> GetListDefinitionAsync(CancellationToken cancellationToken);

        Task<WorkflowDefinitionDetailResponse> GetDetailDefinitionAsync(string id, CancellationToken cancellationToken);

        Task<WorkflowDefinitionCreateResponse> CreateDefinitionAsunc(WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<WorkflowDefinitionEditResponse> EditDefinitionAsunc(string id, WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<string> DeleteDefinitionAsunc(string id, CancellationToken cancellationToken);
    }
}
