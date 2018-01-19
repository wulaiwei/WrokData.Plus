// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：BaseUserManage.cs
// 创建标识：吴来伟 2017-12-22 16:49
// 创建描述：
//  
// 修改标识：吴来伟2017-12-22 16:49
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using WorkData.Infrastructure.Repositories;

namespace Domain.Core.Permissions.Users
{
    /// <summary>
    /// BaseUserManage
    /// </summary>
    public class BaseUserManage: WorkDataBaseManage
    {
        private readonly IBaseRepository<BaseUser, string> _baseUserRep;
        public BaseUserManage(IBaseRepository<BaseUser, string> baseUserRep)
        {
            _baseUserRep = baseUserRep;
        }

        public List<BaseUser> GetAll()
        {
            return _baseUserRep.GetAll()
                .ToList();
        }
    }
}