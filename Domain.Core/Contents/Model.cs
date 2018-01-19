// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：Model.cs
// 创建标识：吴来伟 2018-01-12 15:16
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 15:35
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using WorkData.Code.Entities;

#endregion

namespace Domain.Core.Contents
{
    /// <summary>
    ///     模型
    /// </summary>
    public class Model : BaseAudit, IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        #region Properties

        /// <summary>
        ///     名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     代码
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     状态 是否启用
        /// </summary>
        public virtual bool Status { get; set; }

        /// <summary>
        ///   描述信息
        /// </summary>
        public virtual string Description { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     分类
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }

        /// <summary>
        ///    内容
        /// </summary>
        public virtual ICollection<Content> Contents { get; set; }

        /// <summary>
        ///     模型字段
        /// </summary>
        public virtual ICollection<ModelField> ModelFields { get; set; }

        #endregion Navigation Properties
    }
}