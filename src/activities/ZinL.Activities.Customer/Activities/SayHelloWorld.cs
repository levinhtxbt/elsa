using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elsa;
using Elsa.Activities.Http.Models;
using Elsa.Attributes;
using Elsa.Results;
using Elsa.Services;
using Elsa.Services.Models;

namespace ZinL.Activities.Customer.Activities
{
    [ActivityDefinition(
        Category = "SayHelloWorld",
        DisplayName = "SayHelloWorld",
        Description = "SayHelloWorld.",
        Icon = "fas fa-terminal",
        Outcomes = new[] { OutcomeNames.False, OutcomeNames.True }
    )]
    public class SayHelloWorld : Activity
    {

        [ActivityProperty(Hint = "The message to write.")]
        public string Message
        {

            get => GetState<string>();
            set => SetState(value);
        }

        protected override ActivityExecutionResult OnExecute(WorkflowExecutionContext context)
        {
            //var message = context.CurrentLogEntry.Message;

            //var result = context.CurrentScope.LastResult?.Value;
            var outcomeName = "False";

            //if (result is HttpRequestModel request)
            //{
            //    outcomeName = "True";
            //}

            return Outcome(outcomeName);
            //return Done();
        }
    }
}
