using Elsa.Metadata;
using Elsa.Models;
using Elsa.WorkflowDesigner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZinL.Models.Instance
{
    public class AWFInstanceDetailResponse
    {
        public WorkflowInstance WorkflowInstance { get; set; }
        public WorkflowDefinitionVersion WorkflowDefinition { get; set; }
        public WorkflowModel WorkflowModel { get; set; }
        public ActivityDescriptor[] ActivityDefinitions { get; set; }
        public string ReturnUrl { get; set; }
    }
}
