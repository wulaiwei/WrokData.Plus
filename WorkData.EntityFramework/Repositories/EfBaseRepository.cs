// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.EntityFramework
// 文件名：EfBaseRepository.cs
// 创建标识：吴来伟 2017-12-04 17:57
// 创建描述：
//  
// 修改标识：吴来伟2017-12-04 17:57
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WorkData.Infrastructure.Entities;
using WorkData.Infrastructure.Repositories;

namespace WorkData.EntityFramework.Repositories
{
    /// <summary>
    /// EfBaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class EfBaseRepository<TEntity, TPrimaryKey>: 
        BaseRepository<TEntity, TPrimaryKey>  where TEntity:class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets EF DbContext object.
        /// </summary>
        public virtual DbContext Context => _dbContextProvider.GetContent();

        /// <summary>
        /// Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<TEntity> DbSet => Context.Set<TEntity>();

        private readonly IDbContextProvider<DbContext> _dbContextProvider;

        public EfBaseRepository(IDbContextProvider<DbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public override IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        public override TEntity Insert(TEntity model) 
        {
             return DbSet.Add(model);
        }

        /// <summary>
        /// InsertAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override Task<TEntity> InsertAsync(TEntity model)
        {
            return Task.FromResult(DbSet.Add(model));
        }
    }
}