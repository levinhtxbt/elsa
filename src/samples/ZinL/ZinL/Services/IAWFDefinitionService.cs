using Elsa.Dashboard.Areas.Elsa.ViewModels;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models.Definition;

namespace ZinL.Services
{
    public interface IAWFDefinitionService
    {
        Task<WorkflowDefinitionListViewModel> GetListDefinitionAsync(CancellationToken cancellationToken);

        Task<AWFDefinitionDetailResponse> GetDetailDefinitionAsync(string id, CancellationToken cancellationToken);

        Task<AWFDefinitionCreateResponse> CreateDefinitionAsync(WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<AWFDefinitionEditResponse> EditDefinitionAsync(string id, WorkflowDefinitionEditModel model, CancellationToken cancellationToken);

        Task<string> DeleteDefinitionAsync(string id, CancellationToken cancellationToken);
    }
}
