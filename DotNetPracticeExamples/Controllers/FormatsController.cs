using Microsoft.AspNetCore.Mvc;
using DotNetPracticeExamples.Services.IService;
using System.Collections;

namespace DotNetPracticeExamples.Controllers
{
    [Route("api/FormatsController")]
    [ApiController]
    public class FormatsController : ControllerBase
    {
        private readonly IFormatService _formatService;

        public FormatsController(IFormatService formatService)
        {
            _formatService = formatService;
        }

        [HttpGet("GetAllFormats")]
        public IActionResult GetAllFormats()
        {
            IEnumerable result = _formatService.GetAllFormats();

            if (result != null)
            { return StatusCode(200, result); }
            else
            { return StatusCode(404, "No results found"); }
        }
    }
}