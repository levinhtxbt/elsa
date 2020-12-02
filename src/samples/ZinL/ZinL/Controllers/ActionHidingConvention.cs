using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZinL.Models.Common;

namespace ZinL.Controllers
{
    public class ActionHidingConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            foreach (var item in Constants.HiddenControllerOnSwagger)
            {
                if (action.Controller.ControllerName == item)
                {
                    action.ApiExplorer.IsVisible = false;
                }
            }
        }
    }
}
