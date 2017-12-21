// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：WorkDataSessionExtension.cs
// 创建标识：吴来伟 2017-12-19 16:50
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 16:50
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Linq;
using Domain.Core.Permissions.Users;
using WorkData.Code.Sessions;

namespace Domain.Core.WorkDataSessionExtensions
{
    /// <summary>
    /// WorkDataSessionExtension
    /// </summary>
    public class WorkDataSessionExtension: ClaimsSession, IWorkDataSessionExtension
    {
        public WorkDataSessionExtension(IWorkDataClaimsPrincipal workDataClaimsPrincipal)
            : base(workDataClaimsPrincipal)
        {
        }

        /// <summary>
        /// UserName
        /// </summary>
        public string UserName => GetClaimValue(ClaimTypeExtensions.UserName);


        /// <summary>
        ///     获取申明值
        /// </summary>
        /// <returns></returns>
        public static string GetClaimValue(string claimType)
        {
            var claimsPrincipal = WorkDataClaimsPrincipal.Instance.Principal;

            var claim = claimsPrincipal?.Claims.FirstOrDefault(c => c.Type == claimType);

            return string.IsNullOrEmpty(claim?.Value) ? null : claim.Value;
        }
    }


}