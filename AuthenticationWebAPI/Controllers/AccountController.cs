using JWTAuhtenticationManager;
using JWTAuhtenticationManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JWTTokenHandler _jwtTokenHandler;


        public AccountController(JWTTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        //[HttpPost]
        //public ActionResult<AuthenticationResponse> Authenticate(AuthenticationRequest authenticationRequest)
        //{
            
        //    var authenticationResponse = _jwtTokenHandler.GenerateJWTToken(authenticationRequest);
        //    if (authenticationResponse == null) return Unauthorized();

        //    return authenticationResponse;
        //}
    }
}
