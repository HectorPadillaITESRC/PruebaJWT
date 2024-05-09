using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaJWT.Helper;

namespace PruebaJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {


        [HttpPost]
        public IActionResult Post(string username, string password)
        {
            if (password == "ITESRC")
            {
                JwtTokerGenerator jwtToken = new();
                return Ok(jwtToken.GetToken(username));
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
