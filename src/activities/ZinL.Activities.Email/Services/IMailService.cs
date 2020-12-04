using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZinL.Activities.Email.Services
{
    public interface IMailService
    {
        Task SendAsync(SendEmail email, CancellationToken cancellationToken);
    }
}
