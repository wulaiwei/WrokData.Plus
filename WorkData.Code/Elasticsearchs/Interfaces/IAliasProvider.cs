// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：IAliasProvider.cs
// 创建标识：吴来伟 2018-01-10 14:48
// 创建描述：
//  
// 修改标识：吴来伟2018-01-10 14:48
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;

namespace WorkData.Code.Elasticsearchs.Interfaces
{
    /// <summary>
    /// IAliasProvider
    /// </summary>
    public interface IAliasProvider
    {
        /// <summary>
        /// Alias 别名操作
        /// </summary>
        /// <param name="aliasRequest"></param>
        IBulkAliasResponse Alias(IBulkAliasRequest aliasRequest);
    }
}