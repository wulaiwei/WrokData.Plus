// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Infrastructure
// 文件名：InfrastructurModule.cs
// 创建标识：吴来伟 2017-11-27 15:16
// 创建描述：
//  
// 修改标识：吴来伟2017-11-27 15:16
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using WorkData.Infrastructure.Entities;
using WorkData.Infrastructure.Repositories;
using WorkData.Infrastructure.UnitOfWorks;

namespace WorkData.Infrastructure
{
    public class InfrastructurModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CurrentUnitOfWorkProvider>()
                .As<ICurrentUnitOfWorkProvider>();

            builder.RegisterGeneric(typeof(BaseRepository<,>))
                .As(typeof(IBaseRepository<,>));


            builder.RegisterType<UnitOfWorkManager>()
                .As<IUnitOfWorkManager>();
        }
    }
}