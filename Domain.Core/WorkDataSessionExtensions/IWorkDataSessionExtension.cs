// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：IWorkDataSessionExtension.cs
// 创建标识：吴来伟 2017-12-19 16:49
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 16:49
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Sessions;

namespace Domain.Core.WorkDataSessionExtensions
{
    /// <summary>
    /// IWorkDataSessionExtension
    /// </summary>
    public interface IWorkDataSessionExtension: IWorkDataSession
    {
        /// <summary>
        /// UserName
        /// </summary>
        string UserName { get; }
    }
}