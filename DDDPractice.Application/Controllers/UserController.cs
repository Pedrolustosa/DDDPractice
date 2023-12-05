using System.Net;
using Microsoft.AspNetCore.Mvc;
using DDDPractice.Domain.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using DDDPractice.Domain.Interfaces.Services.User;

namespace DDDPractice.Application.Controllers
{
    /// <summary>
    /// The user controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The user service.
        /// </summary>
        private readonly IUserService _userService;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets the all.
        /// </summary>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
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

        /// <summary>
        /// Get the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
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

        /// <summary>
        /// Post a <see cref="ActionResult"/>.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDtoCreate userEntity)
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

        /// <summary>
        /// Puts a <see cref="ActionResult"/>.
        /// </summary>
        /// <param name="userEntity">The user entity.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDtoUpdate userEntity)
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

        /// <summary>
        /// Deletes a <see cref="ActionResult"/>.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[A Task<ActionResult>.]]></returns>
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