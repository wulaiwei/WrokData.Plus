// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：ClaimTypeExtensions.cs
// 创建标识：吴来伟 2017-12-19 16:51
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 16:51
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Linq;
using System.Security.Claims;
using System.Threading;
using WorkData.Code.Sessions;

namespace Domain.Core.Permissions.Users
{
    public class ClaimTypeExtensions
    {
        /// <summary>
        /// Principal
        /// </summary>
        public virtual ClaimsPrincipal Principal =>
            Thread.CurrentPrincipal as ClaimsPrincipal;

        /// <summary>
        ///     用户名
        /// </summary>
        public const string UserName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/userName";
    }

}