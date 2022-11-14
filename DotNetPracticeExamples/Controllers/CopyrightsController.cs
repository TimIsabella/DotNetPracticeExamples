using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Controllers
{
    [Route("api/CopyrightsController")]
    [ApiController]
    public class CopyrightsController : ControllerBase
    {
        private readonly ICopyrightService _copyrightService;

        public CopyrightsController(ICopyrightService copyrightService)
        {
            _copyrightService = copyrightService;
        }

        [HttpGet("GetAllCopyrights")]
        public IActionResult GetAllCopyrights()
        {
            IEnumerable result = _copyrightService.GetAllCopyrights();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }
    }
}