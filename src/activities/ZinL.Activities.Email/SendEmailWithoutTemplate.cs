using System;
using System.Collections.Generic;
using System.Text;
using Elsa;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Services;

namespace ZinL.Activities.Email
{
    [ActivityDefinition(
        Category = "Email",
        DisplayName = "Send Email Without Template",
        Description = "Send Email Without Template",
        Icon = "fas fa-envelope",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public  class SendEmailWithoutTemplate : SendEmail
    {

        [ActivityProperty(Name = "Body", Hint = "Body", Type = ActivityPropertyTypes.Text)]
        public string Body
        {

            get => GetState<string>();
            set => SetState(value);
        }

       

    }
}
