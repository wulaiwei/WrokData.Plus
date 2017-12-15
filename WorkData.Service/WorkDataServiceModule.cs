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

using Autofac;
using Autofac.Extras.DynamicProxy;
using Domain.EntityFramework;
using WorkData.EntityFramework;
using WorkData.Extensions.Modules;
using WorkData.Infrastructure;

namespace WorkData.Service
{
    [DependsOn(
        typeof(DomainEntityFrameworkModule),
        typeof(EntityFrameworkModule),
        typeof(InfrastructurModule))]
    public class WorkDataServiceModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WalletService>().As<IWalletService>().EnableInterfaceInterceptors().PropertiesAutowired();
            builder.RegisterType<DoService>().As<IDoService>().EnableInterfaceInterceptors().PropertiesAutowired();
        }
    }
}