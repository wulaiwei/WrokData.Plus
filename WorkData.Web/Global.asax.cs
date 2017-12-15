// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：Global.asax.cs
// 创建标识：吴来伟 2017-12-07 11:29
// 创建描述：
//
// 修改标识：吴来伟2017-12-15 17:38
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Mvc;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using WorkData.Infrastructure.UnitOfWorks;
using WorkData.Service;
using WorkData.Web.Extensions.Filters;
using WorkData.WebApi;
using WorkData.WebApi.ResponseExtensions.Filters;

#endregion

namespace WorkData.Web
{
    public class MvcApplication : HttpApplication
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance<WorkDataServiceModule>();

        /// <summary>
        ///     Application_Start
        /// </summary>
        protected void Application_Start()
        {
            //Autofac 注入
            BootstrapWarpper.Initiate();

            var newBuidler = new ContainerBuilder();

            #region WebApi

            var config = GlobalConfiguration.Configuration;
            newBuidler.RegisterApiControllers(Assembly.Load("WorkData.WebApi"));
            newBuidler.Register(c => new ApiUowFilterAttribute(c.Resolve<IUnitOfWorkManager>()));
            newBuidler.RegisterWebApiFilterProvider(config);
            newBuidler.RegisterWebApiModelBinderProvider();

            #endregion

            #region MVC

            newBuidler.RegisterControllers(Assembly.GetExecutingAssembly());
            newBuidler.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();
            //注册过滤器
            newBuidler.Register(c => new WebUowFilterAttribute(c.Resolve<IUnitOfWorkManager>()));
            newBuidler.RegisterFilterProvider();
            newBuidler.RegisterControllers(typeof(MvcApplication).Assembly);

            #endregion

            //update container
            BootstrapWarpper.IocManager.UpdateContainer(newBuidler);

            //AutofacWebApiDependencyResolver
            config.DependencyResolver = new AutofacWebApiDependencyResolver(BootstrapWarpper.IocManager.IocContainer);
            //AutofacDependencyResolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(BootstrapWarpper.IocManager.IocContainer));

            //register api filer
            RegisterGlobalApiFilters(config.Filters);
            //register web filter
            RegisterGlobalWebFilters(GlobalFilters.Filters);

            //注入WebApi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear(); //设置返回值统一为json

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        /// <summary>
        ///     RegisterGlobalFilters
        /// </summary>
        /// <param name="filters"></param>
        public void RegisterGlobalApiFilters(HttpFilterCollection filters)
        {
            var item = BootstrapWarpper.IocManager.Resolve(typeof(ApiUowFilterAttribute)) as ApiUowFilterAttribute;
            filters.Add(item); //注意到了吗? 这里使用了Autofac容易来实例化Filter对象，然后注册到Global Filter中
        }

        /// <summary>
        ///     RegisterGlobalWebFilters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalWebFilters(GlobalFilterCollection filters)
        {
            var item = BootstrapWarpper.IocManager.Resolve(typeof(WebUowFilterAttribute)) as WebUowFilterAttribute;
            filters.Add(item); //注意到了吗? 这里使用了Autofac容易来实例化Filter对象，然后注册到Global Filter中
        }
    }
}