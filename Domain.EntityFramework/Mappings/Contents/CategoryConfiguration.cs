// ------------------------------------------------------------------------------
// Copyright  ����ΰ���� ��Ȩ���С� 
// ��Ŀ����Domain.EntityFramework
// �ļ�����CategoryConfiguration.cs
// ������ʶ������ΰ 2018-01-12 15:38
// ����������
//  
// �޸ı�ʶ������ΰ2018-01-12 15:44
// �޸�������
//  ------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Core.Contents;

#endregion

namespace Domain.EntityFramework.Mappings.Contents
{
    public class CategoryConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            HasKey(p => new {p.Id })
                .ToTable("Category", "dbo");
            // Properties:
            Property(p => p.Id)
                .HasColumnName(@"Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            Property(p => p.ModelId)
                .HasColumnName(@"ModelId")
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            Property(p => p.Name)
                .HasColumnName(@"Name")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.Status)
                .HasColumnName(@"Status")
                .IsRequired()
                .HasColumnType("bit");
            Property(p => p.ParentId)
                .HasColumnName(@"ParentId")
                .HasMaxLength(150)
                .HasColumnType("nvarchar");
            Property(p => p.Layer)
                .HasColumnName(@"Layer")
                .IsRequired()
                .HasColumnType("int");
            Property(p => p.HasLevel)
                .HasColumnName(@"HasLevel")
                .IsRequired()
                .HasColumnType("bit");
            Property(p => p.Sort)
                .HasColumnName(@"Sort")
                .IsRequired()
                .HasColumnType("int");
            Property(p => p.Code)
                .HasColumnName(@"Code")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.FormTemplate)
                .HasColumnName(@"FormTemplate")
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");
            Property(p => p.ListTemplate)
                .HasColumnName(@"ListTemplate")
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");
            Property(p => p.FormJson)
                .HasColumnName(@"FormJson")
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");
            Property(p => p.ListJson)
                .HasColumnName(@"ListJson")
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");
            Property(p => p.ListHead)
                .HasColumnName(@"ListHead")
                .HasMaxLength(4000)
                .HasColumnType("nvarchar");
            // Association:
            HasMany(p => p.Contents)
                .WithOptional(c => c.Category)
                .HasForeignKey(p => new {p.CategoryId})
                .WillCascadeOnDelete(false);
        }
    }
}