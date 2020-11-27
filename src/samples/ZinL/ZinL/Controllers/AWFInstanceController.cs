using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Services;

namespace ZinL.Controllers
{
    [Area("AWF")]
    [Route("[area]/workflow-instance")]
    [ApiController]
    public class AWFInstanceController : SS.Lib.Http.ControllerBase
    {
        private readonly IAWFInstanceService _workflowInstanceService;

        public AWFInstanceController(IAWFInstanceService workflowInstanceService)
        {
            _workflowInstanceService = workflowInstanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkflowDefinition(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowInstanceService.GetListInstanceAsync(cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailWorkflowDefinition(string id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowInstanceService.GetDetailInstanceAsync(id, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateWorkflowDefinition(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var response = await _workflowInstanceService.CreateInstanceAsync(model, cancellationToken);
        //        return Ok(response);
        //    }
        //    else
        //        return ThrowModelErrorsException();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowDefinition(string id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowInstanceService.DeleteInstanceAsync(id, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }
    }
}
