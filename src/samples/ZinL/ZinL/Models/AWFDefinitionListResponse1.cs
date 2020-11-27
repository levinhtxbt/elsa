using Elsa.Dashboard.Areas.Elsa.ViewModels;
using Elsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZinL.Models
{
    public class AWFDefinitionListResponse1
    {
        public IList<IGrouping<string, AWFDefinitionResponse>> WorkflowDefinitions { get; set; }
    }
}
