// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：ContentTextField.cs
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
    ///     ContentTextField
    /// </summary>
    public class ContentTextField :  IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        #region Properties

        /// <summary>
        ///    ContentId
        /// </summary>
        public virtual string ContentId { get; set; }

        /// <summary>
        ///   FieldCode
        /// </summary>
        public virtual string FieldCode { get; set; }

        /// <summary>
        ///    FieldValue
        /// </summary>
        public virtual string FieldValue { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///    Content
        /// </summary>
        public virtual Content Content { get; set; }

        #endregion Navigation Properties
    }
}