using Elsa.Metadata;
using Elsa.Models;
using Elsa.WorkflowDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZinL.Models
{
    public class AWFDefinitionDetailResponse
    {
        public string Id { get; set; }
        public string Json { get; set; }
        public string SubmitAction { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSingleton { get; set; }
        public bool IsDisabled { get; set; }
        public ActivityDescriptor[] ActivityDefinitions { get; set; }
        public WorkflowModel WorkflowModel { get; set; }
    }
}
