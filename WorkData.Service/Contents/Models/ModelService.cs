// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service
// 文件名：ModelService.cs
// 创建标识：吴来伟 2018-01-18 10:54
// 创建描述：
//  
// 修改标识：吴来伟2018-01-18 10:54
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Threading.Tasks;
using Domain.Core.Contents;
using Domain.Core.Contents.Manages;
using Domain.Core.WorkDataSessionExtensions;

namespace WorkData.Service.Contents.Models
{
    public class ModelService: IModelService
    {
        /// <summary>
        ///     WorkDataSession
        /// </summary>
        public IWorkDataSessionExtension WorkDataSession { get; set; }

        private readonly ModelManage _modelManage;
        public ModelService(IWorkDataSessionExtension workDataSession,ModelManage modelManage)
        {
            WorkDataSession = workDataSession;
            _modelManage = modelManage;
        }

        /// <summary>
        /// AddModel
        /// </summary>
        /// <param name="entity"></param>
        public void AddModel(Model entity)
        {
            _modelManage.AddModel(entity);
        }

        /// <summary>
        /// AddModelAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddModelAsync(Model entity)
        {
            await _modelManage.AddModelAsync(entity);
        }

        /// <summary>
        /// AddModelGetId
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string AddModelGetId(Model entity)
        {
            return _modelManage.AddModelGetId(entity);
        }

        /// <summary>
        /// AddModelGetIdAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AddModelGetIdAsync(Model entity)
        {
            return await _modelManage.AddModelGetIdAsync(entity);
        }
    }
}