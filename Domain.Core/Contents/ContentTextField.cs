// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.Core
// �ļ�����ContentTextField.cs
// ������ʶ������ΰ 2018-01-12 15:16
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:36
// �޸�������
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