using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WorkData.WebApi.ResponseExtensions;

namespace WorkData.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            config.MessageHandlers.Add(new WorkDataResponseHandler());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
