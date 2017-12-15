// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Infrastructure
// 文件名：IBaseRepository.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 10:45
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Linq;
using System.Threading.Tasks;
using WorkData.Extensions.Modules;

#endregion

namespace WorkData.Infrastructure.Repositories
{
    /// <summary>
    ///     IBaseRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IBaseRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        ///     Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        TEntity Insert(TEntity model);

        /// <summary>
        ///     Insert
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="model"></param>
        Task<TEntity> InsertAsync(TEntity model);
    }
}