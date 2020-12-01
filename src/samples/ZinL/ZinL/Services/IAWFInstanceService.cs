using Elsa.Dashboard.Areas.Elsa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models.Instance;

namespace ZinL.Services
{
    public interface IAWFInstanceService
    {
        Task<WorkflowInstanceListViewModel> GetListInstanceAsync(AWFInstanceListRequest request, CancellationToken cancellationToken);

        Task<AWFInstanceDetailResponse> GetDetailInstanceAsync(string id, string returnUrl, CancellationToken cancellationToken);

        //Task<AWFInstanceCreateResponse> CreateInstanceAsync(WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<string> DeleteInstanceAsync(string id, CancellationToken cancellationToken);
    }
}
