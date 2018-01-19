// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：BaseUser.cs
// 创建标识：吴来伟 2017-12-19 11:33
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 11:33
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Entities;
using WorkData.Code.WorkDataIdentity;

namespace Domain.Core.Permissions.Users
{
    /// <summary>
    /// BaseUser
    /// </summary>
    public class BaseUser: BaseUserIdentity<string>,IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
    }
}