using HCMS.Application.Common.Helpers;
using HCMS.Application.Login;
using HCMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController(IMediator mediator) : ControllerBase
        {

            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginCommand command)
            {
                if (string.IsNullOrEmpty(command.Email) || string.IsNullOrEmpty(command.Password))
                {
                    return BadRequest("Email and Password are required.");
                }

               
                var jwtToken = await mediator.Send(command);

                return Ok(new { Token = jwtToken });
                  

             }

        }
    
}
