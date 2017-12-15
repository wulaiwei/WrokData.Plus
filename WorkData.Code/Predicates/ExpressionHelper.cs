// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Code
// 文件名：ExpressionHelper.cs
// 创建标识：吴来伟 2017-12-07 11:03
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 11:05
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Linq.Expressions;

#endregion

namespace WorkData.Code.Predicates
{
    /// <summary>
    ///     ExpressionHelper
    /// </summary>
    public class ExpressionHelper
    {
        /// <summary>
        ///     根据条件数据动态生成或连接条件
        /// </summary>
        /// <typeparam name="TSource">集合项类型</typeparam>
        /// <typeparam name="TPrimaryKey"></typeparam>
        /// <param name="sourcePropertyName">待比较的集合项属性</param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static Expression<Func<TSource, bool>> GenerateCondition<TSource, TPrimaryKey>(string sourcePropertyName,
            TPrimaryKey param)
        {
            var lambdaParam = Expression.Parameter(typeof(TSource));
            var type = typeof(TPrimaryKey);
            var leftExpression = Expression.PropertyOrField(lambdaParam, sourcePropertyName);
            var rightExpression = Expression.Constant(param, type);
            var lambdaBody = Expression
                .Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<TSource, bool>>(lambdaBody, lambdaParam);
        }
    }
}