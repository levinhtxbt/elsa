using System;
using System.Collections.Generic;
using System.Text;
using Elsa;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Results;
using Elsa.Services;
using Elsa.Services.Models;

namespace ZinL.Activities.Customer.Activities
{
    [ActivityDefinition(
        Category = "Customer",
        DisplayName = "Data set",
        Description = "Select dataset from list builder",
        Icon = "fas fa-database",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class CustomerDataset : Activity
    {
        [ActivityProperty(Hint = "The message to write.", Type = ActivityPropertyTypes.Select)]
        [SelectOptions("Hello", "there", "this", "is", "list", "builder")]
        public string Filter
        {

            get => GetState<string>();
            set => SetState(value);
        }


        protected override ActivityExecutionResult OnExecute(WorkflowExecutionContext context)
        {
            Console.WriteLine("a");
            return base.OnExecute(context);
        }

    }
}
