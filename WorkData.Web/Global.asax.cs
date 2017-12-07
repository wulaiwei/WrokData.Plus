// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Web
// 文件名：Global.asax.cs
// 创建标识：吴来伟 2017-12-07 11:29
// 创建描述：
//  
// 修改标识：吴来伟2017-12-07 13:33
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WorkData.WebApi;

#endregion

namespace WorkData.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //注入WebApi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();//设置返回值统一为json  

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}