using Elsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZinL.Models
{
    public class WorkflowDefinitionResponse
    {
        public WorkflowDefinitionVersionResponse WorkflowDefinition { get; set; }
        public int ExecutingCount { get; set; }
        public int FaultedCount { get; set; }
        public int AbortedCount { get; set; }
        public int FinishedCount { get; set; }
    }
}
