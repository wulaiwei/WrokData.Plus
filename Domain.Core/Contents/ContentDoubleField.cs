// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：ContentDoubleField.cs
// 创建标识：吴来伟 2018-01-12 15:16
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 15:36
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Code.Entities;

namespace Domain.Core.Contents
{
    /// <summary>
    ///    ContentDoubleField
    /// </summary>
    public class ContentDoubleField :  IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        #region Properties

        /// <summary>
        ///     内容
        /// </summary>
        public virtual string ContentId { get; set; }

        /// <summary>
        ///    字段代码
        /// </summary>
        public virtual string FieldCode { get; set; }

        /// <summary>
        ///     字段值
        /// </summary>
        public virtual double? FieldValue { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     内容
        /// </summary>
        public virtual Content Content { get; set; }

        #endregion Navigation Properties
    }
}