using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Services;

namespace ZinL.Controllers
{
    [Area("AWF")]
    [Route("[area]/workflow-definition")]
    [ApiController]
    public class WorkflowDefinitionController : ControllerBase
    {

        private readonly IWorkflowDefinitionService _workflowDefinitionService;

        public WorkflowDefinitionController(IWorkflowDefinitionService workflowDefinitionService)
        {
            _workflowDefinitionService = workflowDefinitionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkflowDefinition(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.GetListDefinitionAsync(cancellationToken);
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, $"The workflow definition not found");
        }
    }
}
