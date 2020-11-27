using System.Collections.Generic;
using System.Linq;

namespace ZinL.Models.Definition
{
    public class AWFDefinitionListResponse1
    {
        public IList<IGrouping<string, AWFDefinitionResponse>> WorkflowDefinitions { get; set; }
    }
}
