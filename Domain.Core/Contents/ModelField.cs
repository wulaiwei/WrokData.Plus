// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：ModelField.cs
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
    ///    模型字段
    /// </summary>
    public class ModelField : BaseAudit, IEntity<string>
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
        ///   字段类型
        /// </summary>
        public virtual string ControlType { get; set; }

        /// <summary>
        ///     默认值
        /// </summary>
        public virtual string DefaultValue { get; set; }

        /// <summary>
        ///    验证提示信息
        /// </summary>
        public virtual string ValidTipMsg { get; set; }

        /// <summary>
        ///     验证正则表达式
        /// </summary>
        public virtual string ValidPattern { get; set; }

        /// <summary>
        ///    验证错误信息
        /// </summary>
        public virtual string ValidErrorMsg { get; set; }

        /// <summary>
        ///    是否系统字段
        /// </summary>
        public virtual bool? IsSystemField { get; set; }

        /// <summary>
        ///     选项集合（值以;拆分）
        /// </summary>
        public virtual string ItemOption { get; set; }

        /// <summary>
        ///     Html模板
        /// </summary>
        public virtual string HtmlTemplate { get; set; }

        /// <summary>
        ///    系统字段类型
        /// </summary>
        public virtual int FieldType { get; set; }

        /// <summary>
        ///    字段状态
        /// </summary>
        public virtual bool Status { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     模型
        /// </summary>
        public virtual ICollection<Model> Models { get; set; }

        #endregion Navigation Properties
    }
}