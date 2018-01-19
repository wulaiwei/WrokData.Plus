// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：Content.cs
// 创建标识：吴来伟 2018-01-12 15:16
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 15:36
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using WorkData.Code.Entities;

#endregion

namespace Domain.Core.Contents
{
    /// <summary>
    ///     内容
    /// </summary>
    public class Content : BaseAudit, IEntity<string>
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
        ///  分类Id
        /// </summary>
        public virtual string CategoryId { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     分类
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        ///     模型
        /// </summary>
        public virtual Model Model { get; set; }

        /// <summary>
        ///     内容扩展（中等长度字段）
        /// </summary>
        public virtual ICollection<ContentDescriptionField> ContentDescriptionFields { get; set; }

        /// <summary>
        ///      内容扩展（浮点型）
        /// </summary>
        public virtual ICollection<ContentDoubleField> ContentDoubleFields { get; set; }

        /// <summary>
        ///      内容扩展（整数）
        /// </summary>
        public virtual ICollection<ContentIntField> ContentIntFields { get; set; }

        /// <summary>
        ///      内容扩展（字符串）
        /// </summary>
        public virtual ICollection<ContentStringField> ContentStringFields { get; set; }

        /// <summary>
        ///      内容扩展（富文本）
        /// </summary>
        public virtual ICollection<ContentTextField> ContentTextFields { get; set; }

        /// <summary>
        ///      内容扩展（时间）
        /// </summary>
        public virtual ICollection<ContentTimeField> ContentTimeFields { get; set; }

        #endregion Navigation Properties
    }
}