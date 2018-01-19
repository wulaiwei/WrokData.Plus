// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：ModelManage.cs
// 创建标识：吴来伟 2018-01-17 16:07
// 创建描述：
//  
// 修改标识：吴来伟2018-01-17 16:08
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Threading.Tasks;
using WorkData.Infrastructure.Repositories;

#endregion

namespace Domain.Core.Contents.Manages
{
    public class ModelManage : WorkDataBaseManage
    {
        private readonly IBaseRepository<Model, string> _modelRep;

        public ModelManage(IBaseRepository<Model, string> modelRep)
        {
            _modelRep = modelRep;
        }

        /// <summary>
        /// AddModel
        /// </summary>
        /// <param name="entity"></param>
        public void AddModel(Model entity)
        {
            _modelRep.Insert(entity);
        }

        /// <summary>
        /// AddModelAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddModelAsync(Model entity)
        {
            await _modelRep.InsertAsync(entity);
        }

        /// <summary>
        /// AddModelGetId
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public string AddModelGetId(Model entity)
        {
            return _modelRep.InsertGetId(entity);
        }

        /// <summary>
        /// AddModelGetIdAsync
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AddModelGetIdAsync(Model entity)
        {
            return await _modelRep.InsertGetIdAsync(entity);
        }
    }
}