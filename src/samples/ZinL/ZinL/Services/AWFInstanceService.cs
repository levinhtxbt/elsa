using Elsa.Dashboard.Areas.Elsa.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models.Instance;

namespace ZinL.Services
{
    public class AWFInstanceService : IAWFInstanceService
    {
        //public Task<AWFInstanceCreateResponse> CreateInstanceAsync(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        public Task<string> DeleteInstanceAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AWFInstanceDetailResponse> GetDetailInstanceAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<WorkflowInstanceListViewModel> GetListInstanceAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
