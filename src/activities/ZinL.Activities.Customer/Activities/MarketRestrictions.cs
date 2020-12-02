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
        Category = "MarketRestrictions",
        DisplayName = "Market Restrictions",
        Description = "Market Restrictions",
        Icon = "fas fa-minus-circle",
        Outcomes = new[] { OutcomeNames.Done }
    )]
    public class MarketRestrictions : Activity
    {
        [ActivityProperty(Hint = "Distance from dealer filter", Type = ActivityPropertyTypes.Text)]
        public string DistanceFromDealerFilter
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Hint = "In State Only", Type = ActivityPropertyTypes.Boolean)]
        public string InStateOnly
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Hint = "Restricted To States", Type = ActivityPropertyTypes.Boolean)]
        public string RestrictedToStates
        {

            get => GetState<string>();
            set => SetState(value);
        }

        [ActivityProperty(Hint = "Restricted To States", Type = ActivityPropertyTypes.Text)]
        public string RestrictedToStatesInput
        {

            get => GetState<string>();
            set => SetState(value);
        }
    }
}
