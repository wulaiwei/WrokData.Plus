// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：PredicateGroup.cs
// 创建标识：吴来伟 2017-12-07 11:03
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 11:06
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WorkData.Code.Permissions;

#endregion

namespace WorkData.Code.Predicates
{
    /// <summary>
    ///     PredicateGroup
    /// </summary>
    public class PredicateGroup<T> : IPredicateGroup<T> where T : class
    {
        /// <summary>
        /// PredicateConfig
        /// </summary>
        public PredicateConfig PredicateConfig { get; set; }

        /// <summary>
        /// PredicateGroup
        /// </summary>
        /// <param name="predicateConfig"></param>
        public PredicateGroup(PredicateConfig predicateConfig)
        {
            Predicates = new List<WorkDataPredicate<T>>();
            var factory = new object();

            if (predicateConfig.DataPermissionType== DataPermissionType.主账号子账号)
            {

            }
            else
            {
                
            }

        }

        public PredicateGroup(bool isInterceptor)
        {
            Predicates = new List<WorkDataPredicate<T>>();
            if (!isInterceptor) return;

            //TODO 需重构

            var where = ExpressionHelper
                .GenerateCondition<T, long?>("BelongUserId",
                    1);
            var predicate = new WorkDataPredicate<T>
            {
                Condition = true,
                Expression = where
            };

            Predicates.Add(predicate);
        }

        /// <summary>
        ///     PredicateGroup
        /// </summary>
        public PredicateGroup()
        {
            Predicates = new List<WorkDataPredicate<T>>();
        }

        /// <summary>
        ///     Predicates
        /// </summary>
        public List<WorkDataPredicate<T>> Predicates { get; set; }

        /// <summary>
        ///     AddPredicate
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        public void AddPredicate(bool condition, Expression<Func<T, bool>> expression)
        {
            var predicate = new WorkDataPredicate<T>
            {
                Condition = condition,
                Expression = expression
            };

            Predicates.Add(predicate);
        }
    }
}