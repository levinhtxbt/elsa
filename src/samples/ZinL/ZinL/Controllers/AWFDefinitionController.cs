using Elsa.Dashboard.Areas.Elsa.ViewModels;
using Elsa.Models;
using Microsoft.AspNetCore.Http;
using SS.Lib.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Services;

namespace ZinL.Controllers
{
    [Area("AWF")]
    [Route("[area]/workflow-definition")]
    [ApiController]
    public class AWFDefinitionController : SS.Lib.Http.ControllerBase
    {

        private readonly IAWFDefinitionService _workflowDefinitionService;

        public AWFDefinitionController(IAWFDefinitionService workflowDefinitionService)
        {
            _workflowDefinitionService = workflowDefinitionService;
        }

        /// <summary>
        /// Get list workflow definition
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetWorkflowDefinition(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.GetListDefinitionAsync(cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        /// <summary>
        /// Get detail workflow definition
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailWorkflowDefinition(string id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.GetDetailDefinitionAsync(id, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        /// <summary>
        /// Create workflow definition
        /// </summary>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateWorkflowDefinition(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.CreateDefinitionAsync(model, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        /// <summary>
        /// Edit workflow definition
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWorkflowDefinition(string id, WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.EditDefinitionAsync(id, model, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }

        /// <summary>
        /// Delete workflow definition
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowDefinition(string id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.DeleteDefinitionAsync(id, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }
    }
}
