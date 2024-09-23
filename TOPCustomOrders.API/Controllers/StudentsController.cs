using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TOPCustomOrders.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class StudentsController : ControllerBase
    {
        [MapToApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetAllStudentsV1()
        {
            string[] studentNames = new string[] { "Johns", "Jane", "Mark" };

            return Ok(studentNames);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public IActionResult GetAllStudentsV2()
        {
            string[] studentNames = new string[] { "Valerne", "Maria", "Abdul" };

            return Ok(studentNames);
        }
    }
}
