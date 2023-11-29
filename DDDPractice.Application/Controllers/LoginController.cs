using System.Net;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.Application.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService loginService)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(userEntity is null)
                return BadRequest(userEntity);
            
            try
            {
                var result = await loginService.FindByLogin(userEntity);
                if(result is not null)
                    return Ok(result);
                else
                    return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}