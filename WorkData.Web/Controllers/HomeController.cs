using System.Collections.Generic;
using Domain.Core;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Domain.Core.Permissions.Users;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WorkData.Code.Sessions;
using WorkData.Infrastructure.Repositories;
using WorkData.Service;

namespace WorkData.Web.Controllers
{
    /// <summary>
    ///HomeController
    /// </summary>
    public class HomeController : WorkDataBaseController
    {
        private readonly IWalletService _walletService;
        private readonly IBaseRepository<Wallet, int> _rep;

        public HomeController(
            IWalletService walletService, 
            IBaseRepository<Wallet, int> rep)
        {
            _walletService = walletService;
            _rep = rep;
        }

        // GET: Home
        public ActionResult Index()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "123"), //用户Id
                new Claim(ClaimTypeExtensions.UserName, "咋打算发"), //用户Id
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider","ASP.NET Identity")
            };

            #region Identity授权
            //构建身份申明（类似：登机牌，电影票等）
            var claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            //通过Owin Context 获取我们的认证管理
            var ctx = HttpContext.GetOwinContext();
            var authenticationManager = ctx.Authentication;

            //先退出登出（稳妥的做法）
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            //再进行登入（将登机牌给保安验证）
            authenticationManager.SignIn(new AuthenticationProperties { IsPersistent = false }, claimsIdentity);

            #endregion

            _walletService.GetAll();
            var item = _rep.GetAll().ToList();
            return RedirectToAction("LoadSession");
        }

        public ActionResult LoadSession()
        {
            var s = WorkDataSession;
            return View("Index");
        }
    }
}