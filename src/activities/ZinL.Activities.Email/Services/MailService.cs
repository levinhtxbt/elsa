using SS.RabbitMq.Commands;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ZinL.Activities.Email.Services
{
    public class MailService : IMailService
    {
        //private readonly IPublishEndpoint _publishQueueEndpoint;

        //public MailService(IPublishEndpoint publishQueueEndpoint)
        //{
        //    _publishQueueEndpoint = publishQueueEndpoint;
        //}

        //public async Task SendAsync(SendEmail email, CancellationToken cancellationToken)
        //{
        //    var from = email.EmailFromName;
        //    var to = new List<string> { email.ForwardEmailResponseTo };

        //    await _publishQueueEndpoint.Publish<ISendEmailCommand>(new SendEmailCommand
        //    {
        //        From = from,
        //        To = to,
        //        Body = "Test send amil",
        //        Subject = email.EmailSubject,
        //        MessageId = Guid.NewGuid()
        //    });
        //}
        public Task SendAsync(SendEmail email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
