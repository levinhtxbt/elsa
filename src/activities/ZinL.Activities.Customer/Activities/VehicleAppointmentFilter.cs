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
        DisplayName = "VehicleAppointmentFilter",
        Description = "VehicleAppointmentFilter",
        Icon = "fas fa-car",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class VehicleAppointmentFilter : Activity
    {
        [ActivityProperty(Name = "AppointmentBefore", Hint = "Days before appointment", Type = ActivityPropertyTypes.Text)]
        public string AppointmentBefore
        {

            get => GetState<string>();
            set => SetState(value);
        }
    }
}
