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
        DisplayName = "Send Email With Template",
        Description = "Send Email With Template",
        Icon = "fas fa-envelope",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class SendEmailWithTemplate : SendEmail
    {

        [ActivityProperty(Name = "Template", Hint = "Select template to send email", Type = ActivityPropertyTypes.Select)]
        [SelectOptions("Template 1", "Template 2", "Template 3", "Template 4")]
        public string Template
        {

            get => GetState<string>();
            set => SetState(value);
        }

    }
}
