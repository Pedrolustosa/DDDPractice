using System.Net;
using DDDPractice.Domain.DTOs;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.Application.Controllers
{
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDTO loginDTO, [FromServices] ILoginService loginService)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if(loginDTO is null)
                return BadRequest(loginDTO);
            
            try
            {
                var result = await loginService.FindByLogin(loginDTO);
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