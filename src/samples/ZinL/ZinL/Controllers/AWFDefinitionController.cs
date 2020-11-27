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

        [HttpPost]
        public async Task<IActionResult> CreateWorkflowDefinition(WorkflowDefinitionEditModel model, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.CreateDefinitionAsunc(model, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
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
                return ThrowModelErrorsException();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkflowDefinition(string id, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _workflowDefinitionService.DeleteDefinitionAsunc(id, cancellationToken);
                return Ok(response);
            }
            else
                return ThrowModelErrorsException();
        }
    }
}
