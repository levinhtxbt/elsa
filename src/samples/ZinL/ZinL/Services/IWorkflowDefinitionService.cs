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
    }
}
