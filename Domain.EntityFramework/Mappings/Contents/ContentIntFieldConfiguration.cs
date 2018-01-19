// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：ContentIntFieldConfiguration.cs
// 创建标识：吴来伟 2018-01-12 15:38
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 15:44
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Core.Contents;

#endregion

namespace Domain.EntityFramework.Mappings.Contents
{
    public class ContentIntFieldConfiguration : EntityTypeConfiguration<ContentIntField>
    {
        public ContentIntFieldConfiguration()
        {
            HasKey(p => new {p.Id })
                .ToTable("ContentIntField", "dbo");
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
                .HasColumnType("int");
        }
    }
}