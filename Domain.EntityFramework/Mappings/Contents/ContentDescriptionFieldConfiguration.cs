// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：ContentDescriptionFieldConfiguration.cs
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
    public class ContentDescriptionFieldConfiguration : EntityTypeConfiguration<ContentDescriptionField>
    {
        public ContentDescriptionFieldConfiguration()
        {
            HasKey(p => new {p.Id })
                .ToTable("ContentDescriptionField", "dbo");
            // Properties:
            Property(p => p.Id)
                .HasColumnName(@"Id")
                .IsRequired()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            Property(p => p.ContentId)
                .HasColumnName(@"ContentId")
                .HasMaxLength(150)
                .HasColumnType("nvarchar");

            Property(p => p.FieldCode)
                .HasColumnName(@"FieldCode")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.FieldValue)
                .HasColumnName(@"FieldValue")
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
        }
    }
}