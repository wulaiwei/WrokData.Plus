// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.Core
// �ļ�����ContentDoubleField.cs
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
        ///     ����
        /// </summary>
        public virtual string ContentId { get; set; }

        /// <summary>
        ///    �ֶδ���
        /// </summary>
        public virtual string FieldCode { get; set; }

        /// <summary>
        ///     �ֶ�ֵ
        /// </summary>
        public virtual double? FieldValue { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     ����
        /// </summary>
        public virtual Content Content { get; set; }

        #endregion Navigation Properties
    }
}