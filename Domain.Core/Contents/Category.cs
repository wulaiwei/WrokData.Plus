// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С�
// ��Ŀ����Domain.Core
// �ļ�����Category.cs
// ������ʶ������ΰ 2018-01-12 15:16
// ����������
//
// �޸ı�ʶ������ΰ2018-01-12 15:29
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
    public class Category:BaseAudit, IEntity<string>
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
        ///   ��������
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     ״̬
        /// </summary>
        public virtual bool Status { get; set; }

        /// <summary>
        ///     ����ID
        /// </summary>
        public virtual string ParentId { get; set; }

        /// <summary>
        ///   ����
        /// </summary>
        public virtual int Layer { get; set; }

        /// <summary>
        ///     �Ƿ����Ӽ�
        /// </summary>
        public virtual bool HasLevel { get; set; }

        /// <summary>
        ///     ����
        /// </summary>
        public virtual int Sort { get; set; }

        /// <summary>
        ///    �������
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     ��ģ��
        /// </summary>
        public virtual string FormTemplate { get; set; }

        /// <summary>
        ///    �б�ģ��
        /// </summary>
        public virtual string ListTemplate { get; set; }

        /// <summary>
        ///     ��json
        /// </summary>
        public virtual string FormJson { get; set; }

        /// <summary>
        ///     �б�json
        /// </summary>
        public virtual string ListJson { get; set; }

        /// <summary>
        ///     ��ͷ
        /// </summary>
        public virtual string ListHead { get; set; }

        #endregion

        #region Navigation Properties

        /// <summary>
        ///     ģ��
        /// </summary>
        public virtual Model Model { get; set; }

        /// <summary>
        ///    ����
        /// </summary>
        public virtual ICollection<Content> Contents { get; set; }

        #endregion
    }
}