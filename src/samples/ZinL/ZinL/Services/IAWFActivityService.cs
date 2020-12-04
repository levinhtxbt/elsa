using Elsa.Dashboard.Options;
using System.Threading;
using System.Threading.Tasks;

namespace ZinL.Services
{
    public interface IAWFActivityService
    {
        Task<ActivityDefinitionList> GetListActivityAsync(CancellationToken cancellationToken);
    }
}
