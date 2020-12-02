using System;
using System.Collections.Generic;
using System.Text;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Services;

namespace ZinL.Activities.Email
{
    public  abstract class SendEmail : Activity
    {

        [ActivityProperty(Name = "MailType", Hint = "Select email type", Type = ActivityPropertyTypes.Select)]
        [SelectOptions("Code Red", "SendGrid", "MailChimp", "Mailjet")]
        public string MailType
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "EmailFromName", Label = "Email From Name", Hint = "Email From Name", Type = ActivityPropertyTypes.Text)]
        public string EmailFromName
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "ForwardEmailResponseTo", Label = "Forward Email Response To", Hint = "Forward Email Response To", Type = ActivityPropertyTypes.Text)]
        public string ForwardEmailResponseTo
        {

            get => GetState<string>();
            set => SetState(value);
        }


        [ActivityProperty(Name = "EmailSubject", Hint = "EmailSubject", Type = ActivityPropertyTypes.Text)]
        public string EmailSubject
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "ContactName", Hint = "Contact Name", Type = ActivityPropertyTypes.Text)]
        public string ContactName
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "CustomerGreetingPreference", Label = "Customer Greeting Preference", Hint = "Customer Greeting Preference", Type = ActivityPropertyTypes.Boolean)]
        public string CustomerGreetingPreference
        {

            get => GetState<string>();
            set => SetState(value);
        }

    }
}
