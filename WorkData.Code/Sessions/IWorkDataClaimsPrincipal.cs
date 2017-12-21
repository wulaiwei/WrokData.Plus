// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：IWorkDataClaimsPrincipal.cs
// 创建标识：吴来伟 2017-12-19 16:54
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 16:54
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Security.Claims;

namespace WorkData.Code.Sessions
{
    /// <summary>
    /// IWorkDataClaimsPrincipal
    /// </summary>
    public interface IWorkDataClaimsPrincipal
    {
        ClaimsPrincipal Principal { get; }
    }
}