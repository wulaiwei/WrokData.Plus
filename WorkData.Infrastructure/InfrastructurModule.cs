// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：InfrastructurModule.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 9:20
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using WorkData.Extensions.Modules;
using WorkData.Infrastructure.Repositories;
using WorkData.Infrastructure.UnitOfWorks;

#endregion

namespace WorkData.Infrastructure
{
    public class InfrastructurModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkInterceptor>().InstancePerLifetimeScope();

            builder.RegisterType<CurrentUnitOfWorkProvider>()
                .As<ICurrentUnitOfWorkProvider>();

            builder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IBaseRepository<,>));

            builder.RegisterType<UnitOfWorkManager>()
                .As<IUnitOfWorkManager>();
        }
    }
}