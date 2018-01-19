// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.Core
// �ļ�����ModelField.cs
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
    ///    ģ���ֶ�
    /// </summary>
    public class ModelField : BaseAudit, IEntity<string>
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
        ///   �ֶ�����
        /// </summary>
        public virtual string ControlType { get; set; }

        /// <summary>
        ///     Ĭ��ֵ
        /// </summary>
        public virtual string DefaultValue { get; set; }

        /// <summary>
        ///    ��֤��ʾ��Ϣ
        /// </summary>
        public virtual string ValidTipMsg { get; set; }

        /// <summary>
        ///     ��֤������ʽ
        /// </summary>
        public virtual string ValidPattern { get; set; }

        /// <summary>
        ///    ��֤������Ϣ
        /// </summary>
        public virtual string ValidErrorMsg { get; set; }

        /// <summary>
        ///    �Ƿ�ϵͳ�ֶ�
        /// </summary>
        public virtual bool? IsSystemField { get; set; }

        /// <summary>
        ///     ѡ��ϣ�ֵ��;��֣�
        /// </summary>
        public virtual string ItemOption { get; set; }

        /// <summary>
        ///     Htmlģ��
        /// </summary>
        public virtual string HtmlTemplate { get; set; }

        /// <summary>
        ///    ϵͳ�ֶ�����
        /// </summary>
        public virtual int FieldType { get; set; }

        /// <summary>
        ///    �ֶ�״̬
        /// </summary>
        public virtual bool Status { get; set; }

        #endregion Properties

        #region Navigation Properties

        /// <summary>
        ///     ģ��
        /// </summary>
        public virtual ICollection<Model> Models { get; set; }

        #endregion Navigation Properties
    }
}