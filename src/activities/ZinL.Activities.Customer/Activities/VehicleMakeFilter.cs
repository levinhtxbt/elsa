using System;
using System.Collections.Generic;
using System.Text;
using Elsa;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Services;

namespace ZinL.Activities.Customer.Activities
{
    [ActivityDefinition(
        Category = "Vehicle",
        DisplayName = "VehicleMakeFilter",
        Description = "VehicleMakeFilter",
        Icon = "fas fa-car",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class VehicleMakeFilter : Activity
    {

        [ActivityProperty(Name = "VehicleMake", Hint = "VehicleMake", Type = ActivityPropertyTypes.Select)]
        [SelectOptions("Toyota", "BMW", "Mazda", "Ferrari")]
        public string VehicleMake
        {

            get => GetState<string>();
            set => SetState(value);
        }
    }
}
