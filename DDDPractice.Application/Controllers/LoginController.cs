using System.Net;
using DDDPractice.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Controllers
{
    /// <summary>
    /// The login controller.
    /// </summary>
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginDTO">The login DTO.</param>
        /// <param name="loginService">The login service.</param>
        /// <returns><![CDATA[A Task<object>.]]></returns>
        [AllowAnonymous]
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