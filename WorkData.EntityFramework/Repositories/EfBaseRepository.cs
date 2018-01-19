// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：EfBaseRepository.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 10:45
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WorkData.Code.Entities;
using WorkData.Extensions.Modules;
using WorkData.Infrastructure.Repositories;

#endregion

namespace WorkData.EntityFramework.Repositories
{
    /// <summary>
    ///     EfBaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TDbContext"></typeparam>
    public class EfBaseRepository<TDbContext, TEntity, TPrimaryKey> :
        BaseRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
        where TDbContext : DbContext
    {
        /// <summary>
        ///     Gets EF DbContext object.
        /// </summary>
        public virtual TDbContext Context => _dbContextProvider.GetContent();

        /// <summary>
        ///     Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        public EfBaseRepository(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        ///     Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        public override TEntity Insert(TEntity model)
        {
            return DbSet.Add(model);
        }

        /// <summary>
        ///     InsertAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Task<TEntity> InsertAsync(TEntity model)
        {
            return Task.FromResult(DbSet.Add(model));
        }

        /// <summary>
        /// InsertGetId
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override TPrimaryKey InsertGetId(TEntity model)
        {
            model = Insert(model);

            Context.SaveChanges();

            return model.Id;
        }

        /// <summary>
        /// InsertGetIdAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override async Task<TPrimaryKey> InsertGetIdAsync(TEntity model)
        {
            model = await InsertAsync(model);

            Context.SaveChanges();

            return model.Id;
        }
    }
}