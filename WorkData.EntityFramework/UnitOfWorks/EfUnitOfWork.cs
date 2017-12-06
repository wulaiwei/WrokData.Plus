// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.EntityFramework
// 文件名：EfUnitOfWork.cs
// 创建标识：吴来伟 2017-11-27 11:33
// 创建描述：
//  
// 修改标识：吴来伟2017-12-04 15:46
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data.Entity;
using System.Threading.Tasks;
using WorkData.Infrastructure.UnitOfWorks;

#endregion

namespace WorkData.EntityFramework.UnitOfWorks
{
    public class EfUnitOfWork : UnitOfWorkBase
    {
        /// <summary>
        ///     数据库上下文集合
        /// </summary>
        public Dictionary<string, DbContext> InitializedDbContexts;

        private readonly IEfContextFactory _efContextFactory;

        public EfUnitOfWork(IEfContextFactory efContextFactory)
        {
            _efContextFactory = efContextFactory;
            InitializedDbContexts = new Dictionary<string, DbContext>();
        }

        /// <summary>
        /// GetOrCreateDbContext
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <returns></returns>
        public virtual TDbContext GetOrCreateDbContext<TDbContext>()
            where TDbContext : DbContext
        {
            return _efContextFactory
                .GetCurrentDbContext<TDbContext>(InitializedDbContexts);
        }

        /// <summary>
        /// GetOrCreateDbContext
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="conString"></param>
        /// <returns></returns>
        public virtual TDbContext GetOrCreateDbContext<TDbContext>(string conString)
            where TDbContext : DbContext
        {
            return _efContextFactory
                .GetCurrentDbContext<TDbContext>(InitializedDbContexts, conString);
        }


        /// <summary>
        ///     ComplateUnit
        /// </summary>
        protected override void ComplateUnit()
        {
            SaveChanges();
        }

        /// <summary>
        ///     ComplateUnitAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task ComplateUnitAsync()
        {
            await SaveChangesAsync();
        }

        /// <summary>
        ///     DisposeUnit
        /// </summary>
        protected override void DisposeUnit()
        {
            foreach (var item in GetAllInitializedDbContexts())
            {
                Release(item);
            }
        }

        /// <summary>
        ///     Release
        /// </summary>
        /// <param name="item"></param>
        public void Release(DbContext item)
        {
            item.Dispose();
        }

        /// <summary>
        ///     SaveChanges
        /// </summary>
        public override void SaveChanges()
        {
            foreach (var item in GetAllInitializedDbContexts())
            {
                SaveChangesInDbContext(item);
            }
        }

        /// <summary>
        ///     SaveChangesAsync
        /// </summary>
        /// <returns></returns>
        public override async Task SaveChangesAsync()
        {
            foreach (var item in GetAllInitializedDbContexts())
            {
                await SaveChangesInDbContextAsync(item);
            }
        }

        /// <summary>
        ///     GetAllInitializedDbContexts
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<DbContext> GetAllInitializedDbContexts()
        {
            return InitializedDbContexts.Values.ToImmutableList();
        }

        /// <summary>
        ///     SaveChangesInDbContext
        /// </summary>
        /// <param name="dbContext"></param>
        protected virtual void SaveChangesInDbContext(DbContext dbContext)
        {
            dbContext.SaveChanges();
        }

        /// <summary>
        ///     SaveChangesInDbContextAsync
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        protected virtual async Task SaveChangesInDbContextAsync(DbContext dbContext)
        {
            await dbContext.SaveChangesAsync();
        }
    }
}