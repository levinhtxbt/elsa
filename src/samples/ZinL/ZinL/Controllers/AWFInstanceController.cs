using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Models.Instance;
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

        /// <summary>
        /// Get list instance workfklow
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWorkflowInstance(AWFInstanceListRequest request, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowInstanceService.GetListInstanceAsync(request, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        /// <summary>
        /// Get detail instance workfklow
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailWorkflowInstance(string id, string returnUrl, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowInstanceService.GetDetailInstanceAsync(id, returnUrl, cancellationToken);
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

        /// <summary>
        /// Delete instance workfklow
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowInstance(string id, CancellationToken cancellationToken)
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
