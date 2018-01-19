// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.EntityFramework
// �ļ�����ContentTextFieldConfiguration.cs
// ������ʶ������ΰ 2018-01-12 15:38
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:42
// �޸�������
//  ------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Core.Contents;

#endregion

namespace Domain.EntityFramework.Mappings.Contents
{
    public class ContentTextFieldConfiguration : EntityTypeConfiguration<ContentTextField>
    {
        public ContentTextFieldConfiguration()
        {
            this
                .HasKey(p => new {p.Id })
                .ToTable("ContentTextField", "dbo");
            // Properties:
            this
                .Property(p => p.Id)
                .HasColumnName(@"Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(150)
                .HasColumnType("nvarchar");
            this
                .Property(p => p.ContentId)
                .HasColumnName(@"ContentId")
                .HasMaxLength(150)
                .HasColumnType("nvarchar");
            this
                .Property(p => p.FieldCode)
                .HasColumnName(@"FieldCode")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            this
                .Property(p => p.FieldValue)
                .HasColumnName(@"FieldValue")
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");
        }
    }
}