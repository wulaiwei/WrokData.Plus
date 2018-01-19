// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Domain.EntityFramework
// 文件名：DomainEntityFrameworkModule.cs
// 创建标识：吴来伟 2017-12-06 15:12
// 创建描述：
//
// 修改标识：吴来伟2017-12-06 15:12
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using Domain.EntityFramework.EntityFramework;
using WorkData.Code;
using WorkData.Code.Sessions;
using WorkData.EntityFramework;
using WorkData.Extensions.Modules;
using WorkData.Infrastructure;

namespace Domain.EntityFramework
{
    /// <summary>
    /// DomainEntityFrameworkModule
    /// </summary>
    [DependsOn(
        typeof(EntityFrameworkModule),
        typeof(InfrastructurModule),
        typeof(WorkDataCodeModule))]
    public class DomainEntityFrameworkModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterModule<EntityFrameworkModule>(); ;

            //builder.RegisterType<WorkDataContext>()
            //    .As<DbContext>();

            //builder.RegisterType(typeof(WorkDataContext))
            //        //.WithParameter(new NamedParameter("nameOrConnectionString", $"{typeof(WorkDataContext)}"))
            //        .Named($"{typeof(WorkDataContext)}", typeof(DbContext));
            builder.Register(c => new WorkDataContext("WorkDataContext") { WorkDataSession = c.Resolve<IWorkDataSession>() });
        }
    }
}