// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.Core
// �ļ�����Content.cs
// ������ʶ������ΰ 2018-01-12 15:16
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:36
// �޸�������
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using WorkData.Code.Entities;

#endregion

namespace Domain.Core.Contents
{
    /// <summary>
    ///     ����
    /// </summary>
    public class Content : BaseAudit, IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        #region Properties
        /// <summary>
        ///     ģ��Id
        /// </summary>
        public virtual string ModelId { get; set; }

        /// <summary>
        ///  ����Id
        /// </summary>
        public virtual string CategoryId { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     ����
        /// </summary>
        public virtual Category Category { get; set; }

        /// <summary>
        ///     ģ��
        /// </summary>
        public virtual Model Model { get; set; }

        /// <summary>
        ///     ������չ���еȳ����ֶΣ�
        /// </summary>
        public virtual ICollection<ContentDescriptionField> ContentDescriptionFields { get; set; }

        /// <summary>
        ///      ������չ�������ͣ�
        /// </summary>
        public virtual ICollection<ContentDoubleField> ContentDoubleFields { get; set; }

        /// <summary>
        ///      ������չ��������
        /// </summary>
        public virtual ICollection<ContentIntField> ContentIntFields { get; set; }

        /// <summary>
        ///      ������չ���ַ�����
        /// </summary>
        public virtual ICollection<ContentStringField> ContentStringFields { get; set; }

        /// <summary>
        ///      ������չ�����ı���
        /// </summary>
        public virtual ICollection<ContentTextField> ContentTextFields { get; set; }

        /// <summary>
        ///      ������չ��ʱ�䣩
        /// </summary>
        public virtual ICollection<ContentTimeField> ContentTimeFields { get; set; }

        #endregion Navigation Properties
    }
}