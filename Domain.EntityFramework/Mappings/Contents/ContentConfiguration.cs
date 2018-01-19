// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：ContentConfiguration.cs
// 创建标识：吴来伟 2018-01-12 15:38
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 15:43
// 修改描述：
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