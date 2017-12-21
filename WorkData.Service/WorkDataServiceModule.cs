// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Service
// 文件名：WorkDataServiceModule.cs
// 创建标识：吴来伟 2017-12-07 19:33
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 19:33
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Domain.Core;
using Domain.EntityFramework;
using WorkData.Code;
using WorkData.Code.Sessions;
using WorkData.EntityFramework;
using WorkData.Extensions.Modules;
using WorkData.Infrastructure;

namespace WorkData.Service
{
    [DependsOn(
        typeof(DomainCoreModule),
        typeof(DomainEntityFrameworkModule),
        typeof(EntityFrameworkModule),
        typeof(InfrastructurModule),
        typeof(WorkDataCodeModule))]
    public class WorkDataServiceModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //自动用Services里的类来注册相应实例，无须一个个注册
            //builder.RegisterAssemblyTypes(typeof(IWalletService).Assembly)
            //    .Where(t => t.IsClass && t.Name.EndsWith("Service"))
            //    .WithProperty(new NamedPropertyParameter("B", t => t.))
            //    .As(t => t.GetInterfaces())
            //    .InstancePerRequest();

            builder.RegisterType<WalletService>().As<IWalletService>()
                .EnableInterfaceInterceptors().PropertiesAutowired();
            builder.RegisterType<DoService>().As<IDoService>()
                .EnableInterfaceInterceptors().PropertiesAutowired();
        }
    }
}