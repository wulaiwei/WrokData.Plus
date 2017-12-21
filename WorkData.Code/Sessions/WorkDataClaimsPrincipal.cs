// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：WorkDataClaimsPrincipal.cs
// 创建标识：吴来伟 2017-12-19 16:55
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 16:55
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Security.Claims;
using System.Threading;

namespace WorkData.Code.Sessions
{
    public class WorkDataClaimsPrincipal: IWorkDataClaimsPrincipal
    {
        /// <summary>
        /// Principal
        /// </summary>
        public virtual ClaimsPrincipal Principal =>
            Thread.CurrentPrincipal as ClaimsPrincipal;

        public static WorkDataClaimsPrincipal Instance => new WorkDataClaimsPrincipal();
    }
}