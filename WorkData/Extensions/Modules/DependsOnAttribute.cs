// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData
// 文件名：DependsOnAttribute.cs
// 创建标识：吴来伟 2017-12-12 17:44
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 17:44
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace WorkData.Extensions.Modules
{
    /// <summary>
    /// DependsOnAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DependsOnAttribute : Attribute
    {
        public Type[] DependsOnModuleTypes { get; set; }

        public DependsOnAttribute(params Type[] dependsOnModuleTypes)
        {
            DependsOnModuleTypes = dependsOnModuleTypes;
        }
    }
}