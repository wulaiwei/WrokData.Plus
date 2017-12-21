// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Web
// 文件名：Startup.cs
// 创建标识：吴来伟 2017-12-19 16:28
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 16:28
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WorkData.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace WorkData.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                LogoutPath = new PathString("/Account/Logout")
            });

        }
    }
}