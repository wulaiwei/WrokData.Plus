// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：IPredicateGroup.cs
// 创建标识：吴来伟 2017-12-07 11:03
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 11:07
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;

#endregion

namespace WorkData.Code.Predicates
{
    public interface IPredicateGroup<T> where T : class
    {
        List<WorkDataPredicate<T>> Predicates { get; set; }
    }
}