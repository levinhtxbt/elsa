using System;
using System.Collections.Generic;
using System.Text;
using Elsa.Attributes;
using Elsa.Design;
using Elsa.Services;

namespace Elsa.Activities.Workflows.Activities
{
    [ActivityDefinition(
        Category = "Workflows",
        DisplayName = "DailyJobNotification",
        Description = "DailyJobNotification",
        Icon = "fas fa-flag-o",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class DailyJobNotification : Activity
    {
        [ActivityProperty(Name = "MonDay", Hint = "MonDay", Type = ActivityPropertyTypes.Boolean)]
        public string MonDay
        {

            get => GetState<string>();
            set => SetState(value);
        }


        [ActivityProperty(Name = "Tuesday", Hint = "Tuesday", Type = ActivityPropertyTypes.Boolean)]
        public string Tuesday
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "Wednesday", Hint = "Wednesday", Type = ActivityPropertyTypes.Boolean)]
        public string Wednesday
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "Thursday", Hint = "Thursday", Type = ActivityPropertyTypes.Boolean)]
        public string Thursday
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "Friday", Hint = "Friday", Type = ActivityPropertyTypes.Boolean)]
        public string Friday
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "Saturday", Hint = "Saturday", Type = ActivityPropertyTypes.Boolean)]
        public string Saturday
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "Sunday", Hint = "Sunday", Type = ActivityPropertyTypes.Boolean)]
        public string Sunday
        {

            get => GetState<string>();
            set => SetState(value);
        }


        [ActivityProperty(Name = "Recurrence", Hint = "Recurrence", Type = ActivityPropertyTypes.Text)]
        public string Recurrence
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Name = "TimeRange", Hint = "TimeRange", Type = ActivityPropertyTypes.Text)]
        public string TimeRange
        {

            get => GetState<string>();
            set => SetState(value);
        }

    }



}
