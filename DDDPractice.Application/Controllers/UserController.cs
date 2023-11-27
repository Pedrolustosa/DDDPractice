using System.Net;
using DDDPractice.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll([FromServices] IUserService userService)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok(await userService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}