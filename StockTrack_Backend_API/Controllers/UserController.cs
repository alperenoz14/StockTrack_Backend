using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockTrack_Backed_Core.Models;
using StockTrack_Backend_API.Helpers;
using StockTrack_Backend_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StockTrack_Backend_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _appDBContext;
        private readonly JWTService _jwtService;
        public UserController(AppDBContext appDBContext,JWTService jwtService)
        {
            _appDBContext = appDBContext;
            _jwtService = jwtService;

        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var userDb = await _appDBContext.Users.FirstOrDefaultAsync(x => x.Name == user.Name && x.Password == user.Password);

            if (userDb is not null && user.Name == userDb.Name && user.Password == userDb.Password)
            {
                var jwt = _jwtService.Generate(userDb.ID);

                Response.Cookies.Append("jwt", jwt, new CookieOptions
                {
                    HttpOnly = true

                });

                return Ok(new
                {
                    message= "success"
                });
            }

            return BadRequest(new { message = "Invalid Credentials" });

            #region first authentication try
            //var userDb = await _appDBContext.Users.FirstOrDefaultAsync(x => x.Name == user.Name && x.Password == user.Password);


            //if (userDb is not null && user.Name == userDb.Name && user.Password == userDb.Password)
            //{
            //    var claims = new List<Claim>();
            //    claims.Add(new Claim("name", user.Name));
            //    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Name));
            //    claims.Add(new Claim(ClaimTypes.Name, user.Name));

            //    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            //    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            //    await HttpContext.SignInAsync(claimsPrincipal);

            //    return Ok(user);
            //}

            //return Unauthorized();
            #endregion
        }

        [HttpGet]
        public async Task<IActionResult> getAuthenticatedUser()
        {
            try
            {
            var jwt = Request.Cookies["jwt"];

            var token = _jwtService.Verify(jwt);

            int ID = Convert.ToInt32(token.Issuer);

            var user = await _appDBContext.Users.FindAsync(ID);
            return Ok(user);
            }
            catch (Exception _)
            {
                return Unauthorized();
            }
        }

        [Route("Logout")]
        [HttpPost()]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success logout"
            });
        }

    }
}
