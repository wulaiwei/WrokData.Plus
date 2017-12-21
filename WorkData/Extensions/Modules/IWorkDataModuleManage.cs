// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData
// 文件名：IWorkDataModuleManage.cs
// 创建标识：吴来伟 2017-12-18 16:26
// 创建描述：
//  
// 修改标识：吴来伟2017-12-18 16:26
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Extensions.Modules
{
    /// <summary>
    /// IWorkDataModuleManage
    /// </summary>
    public interface IWorkDataModuleManage
    {
        /// <summary>
        /// InitCreateModules
        /// </summary>
        void InitCreateModules(Type startupModule);

        /// <summary>
        /// LoadModules
        /// </summary>
        void LoadModules(Type startupModule);
    }
}