// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：WorkDataContext.cs
// 创建标识：吴来伟 2017-12-06 15:34
// 创建描述：
//  
// 修改标识：吴来伟2017-12-06 15:34
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain.EntityFramework.Mappings;
using WorkData.EntityFramework;

namespace Domain.EntityFramework.EntityFramework
{
    /// <summary>
    /// WorkDataContext
    /// </summary>
    public class WorkDataContext: WorkDataBaseDbContext
    {
        /// <summary>
        /// WorkDataContext
        /// </summary>
        /// <param name="nameOrConnectionString"></param>
        public WorkDataContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
            this.Configuration.AutoDetectChangesEnabled = true;//对多对多，一对多进行curd操作时需要为true
            this.Configuration.LazyLoadingEnabled = false;

            //this.Configuration.AutoDetectChangesEnabled = false;//禁止状态追踪
            //this.Configuration.ProxyCreationEnabled = false;//禁止动态拦截System.Data.Entity.DynamicProxies.
            //自动创建表，如果Entity有改到就更新到表结构
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbEntity, Configuration>());
            Database.SetInitializer<WorkDataContext>(null);
        }

        /// <summary>
        ///     重写模型创建函数
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //默认移除级联删除
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //移除复数表名的契约

            //新增
            modelBuilder.Configurations.Add(new WalletMap());
        }


    }
}