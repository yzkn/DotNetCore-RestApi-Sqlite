using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace DotNetCore_RestApi_Sqlite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private IConfiguration _config;
        private readonly MyContext _context;

        public TokenController(IConfiguration config, MyContext myContext)
        {
            _config = config;
            _context = myContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }
        private string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;


            var item = _context
                .Items
                .AsEnumerable()
                .Where(b => b.Title == login.Username)
                .Where(b => b.Content == login.Password)
                ;

            // DBアクセスの例
            if (item.Count() == 1)
            {
                user = new UserModel { Name = item.First().Title, Email = item.First().Content };
            }

            if ((login.Username == "a" && login.Password == "secret"))
            {
                user = new UserModel { Name = "AAA", Email = "a@example.net" };
            }
            return user;
        }
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        private class UserModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public DateTime Birthdate { get; set; }
        }
    }
}