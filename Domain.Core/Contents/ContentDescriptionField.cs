// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.Core
// �ļ�����ContentDescriptionField.cs
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
    ///     ContentDescriptionField
    /// </summary>
    public class ContentDescriptionField :  IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     ����Id
        /// </summary>
        public virtual string ContentId { get; set; }

        /// <summary>
        ///    �ֶδ���
        /// </summary>
        public virtual string FieldCode { get; set; }

        /// <summary>
        ///     �ֶ�ֵ
        /// </summary>
        public virtual string FieldValue { get; set; }

        #region Navigation Properties

        /// <summary>
        ///     ����
        /// </summary>
        public virtual Content Content { get; set; }

        #endregion Navigation Properties
    }
}