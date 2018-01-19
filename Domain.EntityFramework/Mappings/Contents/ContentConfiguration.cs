// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.EntityFramework
// �ļ�����ContentConfiguration.cs
// ������ʶ������ΰ 2018-01-12 15:38
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:43
// �޸�������
//  ------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Core.Contents;

#endregion

namespace Domain.EntityFramework.Mappings.Contents
{
    public class ContentConfiguration : EntityTypeConfiguration<Content>
    {
        public ContentConfiguration()
        {
            HasKey(p => new {p.Id})
                .ToTable("Content", "dbo");
            // Properties:
            Property(p => p.Id)
                .HasColumnName(@"Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            Property(p => p.ModelId)
                .HasColumnName(@"ModelId")
                .HasMaxLength(150)
                .HasColumnType("nvarchar");
            Property(p => p.CategoryId)
                .HasColumnName(@"CategoryId")
                .HasMaxLength(150)
                .HasColumnType("nvarchar");
            // Associations:
            HasMany(p => p.ContentDescriptionFields)
                .WithOptional(c => c.Content)
                .HasForeignKey(p => new {p.ContentId})
                .WillCascadeOnDelete(true);
            HasMany(p => p.ContentDoubleFields)
                .WithOptional(c => c.Content)
                .HasForeignKey(p => new {p.ContentId})
                .WillCascadeOnDelete(true);
            HasMany(p => p.ContentIntFields)
                .WithOptional(c => c.Content)
                .HasForeignKey(p => new {p.ContentId})
                .WillCascadeOnDelete(true);
            HasMany(p => p.ContentStringFields)
                .WithOptional(c => c.Content)
                .HasForeignKey(p => new {p.ContentId})
                .WillCascadeOnDelete(true);
            HasMany(p => p.ContentTextFields)
                .WithOptional(c => c.Content)
                .HasForeignKey(p => new {p.ContentId})
                .WillCascadeOnDelete(true);
            HasMany(p => p.ContentTimeFields)
                .WithOptional(c => c.Content)
                .HasForeignKey(p => new {p.ContentId})
                .WillCascadeOnDelete(true);
        }
    }
}