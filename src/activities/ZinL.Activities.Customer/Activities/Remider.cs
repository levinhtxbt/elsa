using Elsa;
using Elsa.Attributes;
using Elsa.Services;

namespace ZinL.Activities.Customer.Activities
{
    [ActivityDefinition(
       Category = "Customer",
       DisplayName = "Remider",
       Description = "Send notification when a user action want to remider something.",
       Icon = "fa fa-bullhorn",
       Outcomes = new[] { OutcomeNames.Done }
   )]
    public class Remider : Activity
    {
    }
}
