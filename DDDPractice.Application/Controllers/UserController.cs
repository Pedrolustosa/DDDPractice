using System.Net;
using DDDPractice.Domain.Entities;
using DDDPractice.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetUserById")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok(await _userService.GetById(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity userEntity)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = await _userService.Post(userEntity);
                if (result is not null) return Created(new Uri(Url.Link("GetUserById", new { id = result.Id }) ?? string.Empty), result);
                else return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity userEntity)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var result = await _userService.Put(userEntity);
                if (result is not null) return Ok(result);
                else return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete]
        [Route("{id}", Name = "DeleteUserById")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok(await _userService.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}