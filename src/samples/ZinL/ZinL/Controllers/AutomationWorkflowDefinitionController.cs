using Elsa.Dashboard.Areas.Elsa.ViewModels;
using Elsa.Models;
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
    public class AutomationWorkflowDefinitionController : ControllerBase
    {

        private readonly IWorkflowDefinitionService _workflowDefinitionService;

        public AutomationWorkflowDefinitionController(IWorkflowDefinitionService workflowDefinitionService)
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailWorkflowDefinition(string id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.GetDetailDefinitionAsync(id, cancellationToken);
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, $"The workflow definition not found");
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkflowDefinition(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.CreateDefinitionAsunc(model, cancellationToken);
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, $"The workflow definition can't create");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditWorkflowDefinition(string id, WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.EditDefinitionAsunc(id, model, cancellationToken);
                return Ok(response);
            }
            else
                return StatusCode(StatusCodes.Status404NotFound, $"The workflow definition can't edit");
        }
    }
}
