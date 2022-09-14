using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TestController : BaseApiController
    {
        [HttpGet("GetNumber")]
        public IActionResult GetNumber()
        {
            return Ok("Ran successfully!!");
        }
    }
}
