// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Domain.Core
// 文件名：Category.cs
// 创建标识：吴来伟 2018-01-12 15:16
// 创建描述：
//
// 修改标识：吴来伟2018-01-12 15:29
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using WorkData.Code.Entities;

#endregion

namespace Domain.Core.Contents
{
    /// <summary>
    ///     分类
    /// </summary>
    public class Category:BaseAudit, IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        #region Properties

        /// <summary>
        ///     模型Id
        /// </summary>
        public virtual string ModelId { get; set; }

        /// <summary>
        ///   分类名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     状态
        /// </summary>
        public virtual bool Status { get; set; }

        /// <summary>
        ///     父级ID
        /// </summary>
        public virtual string ParentId { get; set; }

        /// <summary>
        ///   级别
        /// </summary>
        public virtual int Layer { get; set; }

        /// <summary>
        ///     是否含有子集
        /// </summary>
        public virtual bool HasLevel { get; set; }

        /// <summary>
        ///     排序
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        ///    分类代码
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     表单模板
        /// </summary>
        public virtual string FormTemplate { get; set; }

        /// <summary>
        ///    列表模板
        /// </summary>
        public virtual string ListTemplate { get; set; }

        /// <summary>
        ///     表单json
        /// </summary>
        public virtual string FormJson { get; set; }

        /// <summary>
        ///     列表json
        /// </summary>
        public virtual string ListJson { get; set; }

        /// <summary>
        ///     列头
        /// </summary>
        public virtual string ListHead { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        ///     模型
        /// </summary>
        public virtual Model Model { get; set; }

        /// <summary>
        ///    内容
        /// </summary>
        public virtual ICollection<Content> Contents { get; set; }

        #endregion
    }
}