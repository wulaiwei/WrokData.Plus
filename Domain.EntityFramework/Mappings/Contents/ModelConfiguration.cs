// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.EntityFramework
// �ļ�����ModelConfiguration.cs
// ������ʶ������ΰ 2018-01-12 15:38
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:41
// �޸�������
//  ------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Core.Contents;

#endregion

namespace Domain.EntityFramework.Mappings.Contents
{
    public class ModelConfiguration : EntityTypeConfiguration<Model>
    {
        public ModelConfiguration()
        {
            HasKey(p => new {p.Id})
                .ToTable("Model", "dbo");
            // Properties:
            Property(p => p.Id)
                .HasColumnName(@"Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(150)
                .HasColumnType("nvarchar");
            Property(p => p.Name)
                .HasColumnName(@"Name")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.Code)
                .HasColumnName(@"Code")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.Status)
                .HasColumnName(@"Status")
                .IsRequired()
                .HasColumnType("bit");
            Property(p => p.Description)
                .HasColumnName(@"Description")
                .HasMaxLength(200)
                .HasColumnType("nvarchar");
            // Associations:
            HasMany(p => p.Categories)
                .WithOptional(c => c.Model)
                .HasForeignKey(p => new {p.ModelId})
                .WillCascadeOnDelete(false);
            HasMany(p => p.Contents)
                .WithOptional(c => c.Model)
                .HasForeignKey(p => new {p.ModelId})
                .WillCascadeOnDelete(false);
        }
    }
}