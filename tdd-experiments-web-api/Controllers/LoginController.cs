using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace TDDWebAPI.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            var redirectResult = Redirect("/invalidlogin");
            return redirectResult;
        }
    }
}
