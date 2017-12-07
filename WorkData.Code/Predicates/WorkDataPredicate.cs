// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：WorkDataPredicate.cs
// 创建标识：吴来伟 2017-12-07 11:03
// 创建描述：
//  
// 修改标识：吴来伟2017-12-07 11:04
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Linq.Expressions;

#endregion

namespace WorkData.Code.Predicates
{
    /// <summary>
    ///     功能：条件过滤类
    /// </summary>
    public class WorkDataPredicate<T> where T : class
    {
        /// <summary>
        /// </summary>
        public bool Condition { get; set; }

        /// <summary>
        /// </summary>
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}