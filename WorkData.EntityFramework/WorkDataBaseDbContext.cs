// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：WorkDataDbContext.cs
// 创建标识：吴来伟 2017-12-05 9:36
// 创建描述：
//
// 修改标识：吴来伟2017-12-05 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Data.Entity;

#endregion

namespace WorkData.EntityFramework
{
    /// <summary>
    ///     WorkDataDbContext
    /// </summary>
    public abstract class WorkDataBaseDbContext : DbContext
    {
        protected WorkDataBaseDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
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
        }
    }
}