// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service
// 文件名：IModelService.cs
// 创建标识：吴来伟 2018-01-17 17:57
// 创建描述：
//  
// 修改标识：吴来伟2018-01-17 17:57
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Threading.Tasks;
using Domain.Core.Contents;

namespace WorkData.Service.Contents.Models
{
    /// <summary>
    /// ModelService
    /// </summary>
    public interface IModelService:IDomainService
    {
        /// <summary>
        /// AddModel
        /// </summary>
        /// <param name="entity"></param>
        void AddModel(Model entity);

        /// <summary>
        /// AddModelAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddModelAsync(Model entity);
        /// <summary>
        /// AddModelGetId
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string AddModelGetId(Model entity);

        /// <summary>
        /// AddModelGetIdAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<string> AddModelGetIdAsync(Model entity);
    }
}