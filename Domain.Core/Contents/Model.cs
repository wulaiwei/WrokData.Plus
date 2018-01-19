// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.Core
// �ļ�����Model.cs
// ������ʶ������ΰ 2018-01-12 15:16
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:35
// �޸�������
//  ------------------------------------------------------------------------------

#region

using System.Collections.Generic;
using WorkData.Code.Entities;

#endregion

namespace Domain.Core.Contents
{
    /// <summary>
    ///     ģ��
    /// </summary>
    public class Model : BaseAudit, IEntity<string>
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        #region Properties

        /// <summary>
        ///     ����
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        ///     ����
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        ///     ״̬ �Ƿ�����
        /// </summary>
        public virtual bool Status { get; set; }

        /// <summary>
        ///   ������Ϣ
        /// </summary>
        public virtual string Description { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     ����
        /// </summary>
        public virtual ICollection<Category> Categories { get; set; }

        /// <summary>
        ///    ����
        /// </summary>
        public virtual ICollection<Content> Contents { get; set; }

        /// <summary>
        ///     ģ���ֶ�
        /// </summary>
        public virtual ICollection<ModelField> ModelFields { get; set; }

        #endregion Navigation Properties
    }
}