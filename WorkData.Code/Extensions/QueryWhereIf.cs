// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：QueryWhereIf.cs
// 创建标识：吴来伟 2017-12-07 11:20
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 11:20
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using System.Linq;
using WorkData.Code.Predicates;

#endregion

namespace WorkData.Code.Extensions
{
    public static class QueryWhereIf
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicateList"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, List<WorkDataPredicate<T>> predicateList)
            where T : class
        {
            return predicateList.Aggregate(source,
                (current, predicate) =>
                    predicate.Condition ? current.Where(predicate.Expression) : current);
        }
    }
}