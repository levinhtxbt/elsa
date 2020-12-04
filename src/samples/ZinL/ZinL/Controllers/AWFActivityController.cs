using Microsoft.AspNetCore.Mvc;
using SS.Lib.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZinL.Domain;
using ZinL.Services;

namespace ZinL.Controllers
{
    [Area("AWF")]
    [Route("[area]/Activity")]
    [ApiController]
    public class AWFActivityController : SS.Lib.Http.ControllerBase
    {
        private readonly IAWFActivityService _activityService;
       

        public AWFActivityController(IAWFActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// Get list activity
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetListActivity(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var response = await _activityService.GetListActivityAsync(cancellationToken);
                return Ok(response);
            }
            else
            {
                return ThrowModelErrorsException();
            }
        }
    }
}
