// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EntityFrameworkModule.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 9:39
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Autofac;
using WorkData.Code;
using WorkData.Code.Helpers;
using WorkData.EntityFramework.Extensions;
using WorkData.EntityFramework.Repositories;
using WorkData.EntityFramework.UnitOfWorks;
using WorkData.Extensions.Modules;
using WorkData.Extensions.Types;
using WorkData.Infrastructure;
using WorkData.Infrastructure.Repositories;
using WorkData.Infrastructure.UnitOfWorks;

#endregion

namespace WorkData.EntityFramework
{
    /// <summary>
    ///     EntityFrameworkModule
    /// </summary>
    [DependsOn(
        typeof(InfrastructurModule)
        ,typeof(WorkDataCodeModule))]
    public class EntityFrameworkModule : WorkDataBaseModule
    {
        private readonly ILoadType _loadType;

        public EntityFrameworkModule()
        {
            _loadType = NullLoadType.Instance;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var item = IocManager;
            //builder.RegisterModule<InfrastructurModule>();

            builder.RegisterType<EfContextFactory>()
                .As<IEfContextFactory>();

            builder.RegisterGeneric(typeof(DbContentProvider<>))
                .As(typeof(IDbContextProvider<>));

            builder.RegisterType<EfUnitOfWork>()
                .As<IUnitOfWork, IActiveUnitOfWork, IUnitOfWorkCompleteHandle>();

            RegisterMatchDbContexts();
        }

        /// <summary>
        ///     RegisterMatchDbContexts
        /// </summary>
        private void RegisterMatchDbContexts()
        {
            if (IocManager == null)
                return;
            var types = _loadType.GetAll(x => x.IsPublic && x.IsClass && !x.IsAbstract
                                              && typeof(WorkDataBaseDbContext).IsAssignableFrom(x));
            var builder = new ContainerBuilder();
            foreach (var type in types)
            {
                var entityTypeInfos = DbContextHelper.GetEntityTypeInfos(type);
                foreach (var entityTypeInfo in entityTypeInfos)
                {
                    var primaryKeyType = EntityHelper.GetPrimaryKeyType(entityTypeInfo.EntityType);
                    var genericRepositoryType = typeof(IBaseRepository<,>).MakeGenericType(entityTypeInfo.EntityType, primaryKeyType);

                    var baseImplType = typeof(EfBaseRepository<,,>);
                    var implType = baseImplType.MakeGenericType(entityTypeInfo.DeclaringType, entityTypeInfo.EntityType, primaryKeyType);
                    builder.RegisterType(implType).As(genericRepositoryType);
                }
            }
            IocManager.UpdateContainer(builder);
        }
    }
}