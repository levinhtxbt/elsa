using Elsa.Dashboard.Options;
using Elsa.Persistence.EntityFrameworkCore.DbContexts;
using Elsa.Serialization;
using Elsa.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using SS.Lib.Http;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Domain;

namespace ZinL.Services
{
    public class AWFActivityService : IAWFActivityService
    {
        private readonly ElsaDBContext _elsaDBContext;
        private readonly IWorkflowPublisher _publisher;
        private readonly IWorkflowSerializer _serializer;
        private readonly IOptions<ElsaDashboardOptions> _options;

        public AWFActivityService(ElsaContext elsaDBContext,
            IWorkflowPublisher publisher,
            IWorkflowSerializer serializer,
            IOptions<ElsaDashboardOptions> options)
        {
            _elsaDBContext = (ElsaDBContext)elsaDBContext;
            _publisher = publisher;
            _serializer = serializer;
            _options = options;
        }

        public Task<ActivityDefinitionList> GetListActivityAsync(CancellationToken cancellationToken)
        {
            var activityDefinitions = new ActivityDefinitionList();

            activityDefinitions = _options.Value.ActivityDefinitions;

            if (activityDefinitions == null)
            {
                throw new ErrorException(StatusCodes.Status404NotFound, "Activity is not found.");
            }

            return Task.FromResult<ActivityDefinitionList>(activityDefinitions);
        }
    }
}
