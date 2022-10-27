// AuthController.cs
using BlazorJTWAuth.Server.Models;
using BlazorJTWAuth.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlazorExample.Server.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private string CreateJWT(User user)
        {
            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("THIS IS THE SECRET KEY")); // NOTE: SAME KEY AS USED IN Program.cs FILE
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[] // NOTE: could also use List<Claim> here
			{
                new Claim(ClaimTypes.Name, user.Email), // NOTE: this will be the "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, user.Email) // NOTE: this could a unique ID assigned to the user by a database
			};

            var token = new JwtSecurityToken(issuer: "domain.com", audience: "domain.com", claims: claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private IUserDatabase userdb { get; }

        public AuthController(IUserDatabase userdb)
        {
            this.userdb = userdb;
        }

        [HttpPost]
        [Route("api/auth/register")]
        public async Task<LoginResult> Post([FromBody] RegModel reg)
        {
            if (reg.password != reg.confirmpwd)
                return new LoginResult { message = "Password and confirm password do not match.", success = false };
            User newuser = await userdb.AddUser(reg.email, reg.password);
            if (newuser != null)
                return new LoginResult { message = "Registration successful.", jwtBearer = CreateJWT(newuser), email = reg.email, success = true };
            return new LoginResult { message = "User already exists.", success = false };
        }

        [HttpPost]
        [Route("api/auth/login")]
        public async Task<LoginResult> Post([FromBody] LoginModel log)
        {
            User user = await userdb.AuthenticateUser(log.email, log.password);
            if (user != null)
                return new LoginResult { message = "Login successful.", jwtBearer = CreateJWT(user), email = log.email, success = true };
            return new LoginResult { message = "User/password not found.", success = false };
        }
    }
}