namespace EVNETest.Controllers.Auth
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using EVNETest.Auth;
    using EVNETest.Auth.DTO;
    using EVNETest.Business.Managers.Interfaces;
    using EVNETest.Core.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.Tokens;

    [Route("account")]
    public class AccountController : Controller
    {
        #region Fields

        private IUserManager UserManager { get; }

        #endregion

        #region Constructors

        public AccountController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        #endregion

        #region Actions

        [HttpPost, Route("signIn")]
        public async Task<IActionResult> SignIn([FromBody]SignInDTO loginModel)
        {
            var user = await UserManager.GetByCredentialsAsync(loginModel.Email, loginModel.Password);
            if (user == null)
            {
                //...
            }
            var now = DateTime.Now;

            var jwt = new JwtSecurityToken
            (
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.Key, SecurityAlgorithms.HmacSha256),
                claims: new List<Claim> {
                    new Claim(type: "user-id", value: user.Id.ToString())
                } 
            );
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return Ok(new
            {
                token = encodedJwt
            });
        }

        [HttpPost, Route("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpDTO model)
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password
            };
            await UserManager.CreateAsync(user);
            return Ok();
        }

        #endregion
    }
}