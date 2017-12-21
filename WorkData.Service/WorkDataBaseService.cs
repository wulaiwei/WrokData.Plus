// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Service
// 文件名：WorkDataBaseService.cs
// 创建标识：吴来伟 2017-12-20 17:31
// 创建描述：
//  
// 修改标识：吴来伟2017-12-20 17:32
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Sessions;

namespace WorkData.Service
{
    /// <summary>
    /// WorkDataBaseService
    /// </summary>
    public class WorkDataBaseService
    {
        /// <summary>
        /// Used to get current session values.
        /// </summary>
        public IWorkDataSession WorkDataSession { get; set; }
    }
}