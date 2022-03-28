using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shopping_cart.application.Auth.Queries;
using VietBND.AspNetCore;

namespace shopping_cart_api.Controllers
{
    [Route("api/auth")]
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AccountLoginQueries request)
        {
            var response = await _mediator.Send<AccountLoginSuccessDto>(request);
            return Ok(response);
        }

        [HttpPost("loginv2")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginByThirdParty()
        {
            return Ok();
        }

        
    }
}
