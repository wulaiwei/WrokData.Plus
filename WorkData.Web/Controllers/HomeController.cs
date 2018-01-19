// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Web
// 文件名：HomeController.cs
// 创建标识：吴来伟 2017-12-07 13:36
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 17:00
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Domain.Core.Contents;
using Domain.Core.Permissions.Users;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WorkData.Service.Contents.Models;

#endregion

namespace WorkData.Web.Controllers
{
    /// <summary>
    ///     HomeController
    /// </summary>
    public class HomeController : WorkDataBaseController
    {
        private readonly IModelService _modelService;
        public HomeController(IModelService modelService)
        {
            _modelService = modelService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "123"), //用户Id
                new Claim(ClaimTypeExtensions.UserName, "咋打算发"), //用户Id
                new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider",
                    "ASP.NET Identity")
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
            authenticationManager.SignIn(new AuthenticationProperties {IsPersistent = false}, claimsIdentity);

            #endregion

            return RedirectToAction("LoadSession");
        }

        public ActionResult LoadSession()
        {
            var model = new Model()
            {
                Code="SS",
                Name="ASDFASDF",
                Id="1231111123"
            };
            _modelService.AddModelGetId(model);
            return View("Index");
        }
    }
}