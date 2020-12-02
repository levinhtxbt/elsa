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
        DisplayName = "Set Value",
        Description = "Set Value",
        Icon = "fas fa-pen",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class SetProperty : Activity
    {

    }
}
