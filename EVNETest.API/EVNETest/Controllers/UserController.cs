namespace EVNETest.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using EVNETest.Business.Managers.Interfaces;
    using EVNETest.Controllers.Base;
    using Microsoft.AspNetCore.Mvc;

    [Route("user")]
    public class UserController : BaseController
    {
        #region Fields

        private IUserManager UserManager { get; }

        #endregion

        #region Constructors

        public UserController(IUserManager userManager)
        {
            UserManager = userManager;
        }

        #endregion

        #region Actions

        public async Task<IActionResult> GetCurrentUserAsync() 
        {
            var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "user-id").Value);
            return Ok(await UserManager.GetByIdAsync(userId));
        }

        #endregion
    }
}