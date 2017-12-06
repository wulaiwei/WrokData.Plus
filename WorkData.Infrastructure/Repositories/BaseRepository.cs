// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Infrastructure
// 文件名：BaseRepository.cs
// 创建标识：吴来伟 2017-12-04 17:46
// 创建描述：
//  
// 修改标识：吴来伟2017-12-04 17:46
// 修改描述：
//  ------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Threading.Tasks;
using WorkData.Dependency;
using WorkData.Infrastructure.Entities;
using WorkData.Infrastructure.UnitOfWorks;

namespace WorkData.Infrastructure.Repositories
{
    /// <summary>
    /// BaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class BaseRepository<TEntity, TPrimaryKey> : 
        IBaseRepository<TEntity, TPrimaryKey> where TEntity:class, IEntity<TPrimaryKey>
    {
        /// <summary>
        /// UnitOfWorkManager
        /// </summary>
        public IUnitOfWorkManager UnitOfWorkManager { get; set; }

        /// <summary>
        /// IocResolver
        /// </summary>
        public IResolver IocResolver { get; set; }

        /// <summary>
        /// IQueryable
        /// </summary>
        /// <returns></returns>
        public abstract IQueryable<TEntity> GetAll();

        /// <summary>
        /// Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        public abstract TEntity Insert(TEntity model);

        /// <summary>
        /// InsertAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public abstract Task<TEntity> InsertAsync(TEntity model);
    }
}