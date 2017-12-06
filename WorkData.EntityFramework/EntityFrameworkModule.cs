// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.EntityFramework
// 文件名：EntityFrameworkModule.cs
// 创建标识：吴来伟 2017-12-04 16:18
// 创建描述：
//  
// 修改标识：吴来伟2017-12-05 11:11
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using Autofac;
using WorkData.EntityFramework.Repositories;
using WorkData.EntityFramework.UnitOfWorks;
using WorkData.Infrastructure;
using WorkData.Infrastructure.Entities;
using WorkData.Infrastructure.Repositories;
using WorkData.Infrastructure.UnitOfWorks;

#endregion

namespace WorkData.EntityFramework
{
    /// <summary>
    ///     EntityFrameworkModule
    /// </summary>
    public class EntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<InfrastructurModule>();

            builder.RegisterType<EfContextFactory>()
                .As<IEfContextFactory>();

            builder.RegisterGeneric(typeof(DbContentProvider<>))
                .As(typeof(IDbContextProvider<>));

            builder.RegisterType<EfUnitOfWork>()
                .As<IUnitOfWork, IActiveUnitOfWork, IUnitOfWorkCompleteHandle>();

            builder.RegisterGeneric(typeof(EfBaseRepository<,>))
                .As(typeof(IBaseRepository<,>));

        }
    }
}