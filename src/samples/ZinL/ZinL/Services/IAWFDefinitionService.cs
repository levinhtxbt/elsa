using Elsa.Dashboard.Areas.Elsa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models;

namespace ZinL.Services
{
    public interface IAWFDefinitionService
    {
        Task<WorkflowDefinitionListViewModel> GetListDefinitionAsync(CancellationToken cancellationToken);

        Task<AWFDefinitionDetailResponse> GetDetailDefinitionAsync(string id, CancellationToken cancellationToken);

        Task<AWFDefinitionCreateResponse> CreateDefinitionAsunc(WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<AWFDefinitionEditResponse> EditDefinitionAsunc(string id, WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<string> DeleteDefinitionAsunc(string id, CancellationToken cancellationToken);
    }
}
