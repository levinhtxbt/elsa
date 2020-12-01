using Elsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZinL.Models.Instance
{
    public class AWFInstanceListRequest
    {
        public string DefinitionId { get; set; }
        public WorkflowStatus Status { get; set; }
    }
}
