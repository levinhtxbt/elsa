using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Services;

namespace ZinL.Activities.Sms
{
    [ActivityDefinition(
        Category = "Sms",
        DisplayName = "Send Sms",
        Description = "Send sms",
        Icon = "fas fa-terminal",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class SendSms : Activity
    {

        [ActivityProperty(Name = "SmsProvider", Hint = "Sms provider", Type = ActivityPropertyTypes.Select)]
        [SelectOptions("Twilio", "MailChip", "Nextmo SMS", "ClickSend")]
        public string SmsProvider
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "From", Hint = "From", Type = ActivityPropertyTypes.Text)]
        public string From
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "To", Hint = "To", Type = ActivityPropertyTypes.Text)]
        public string To
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "Body", Hint = "Body", Type = ActivityPropertyTypes.Text)]
        public string Body
        {

            get => GetState<string>();
            set => SetState(value);
        }

    }
}
