using System;
using System.Collections.Generic;
using System.Text;
using Elsa;
using Elsa.Attributes;
using Elsa.Services;

namespace ZinL.Activities.Customer.Activities
{
    [ActivityDefinition(
        Category = "ControlFlow",
        DisplayName = "Delay until Event",
        Description = "Delay until Event",
        Icon = "fas fa-calendar",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class DelayUntilEvent : Activity
    {
    }
}
