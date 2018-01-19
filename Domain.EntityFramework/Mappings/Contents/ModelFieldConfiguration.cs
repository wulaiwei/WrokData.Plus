// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：ModelFieldConfiguration.cs
// 创建标识：吴来伟 2018-01-12 15:38
// 创建描述：
//  
// 修改标识：吴来伟2018-01-12 15:39
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Domain.Core.Contents;

#endregion

namespace Domain.EntityFramework.Mappings.Contents
{
    public class ModelFieldConfiguration : EntityTypeConfiguration<ModelField>
    {
        public ModelFieldConfiguration()
        {
            HasKey(p => new {p.Id})
                .ToTable("ModelField", "dbo");
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
            Property(p => p.ControlType)
                .HasColumnName(@"ControlType")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.DefaultValue)
                .HasColumnName(@"DefaultValue")
                .HasMaxLength(50)
                .HasColumnType("nvarchar");
            Property(p => p.ValidTipMsg)
                .HasColumnName(@"ValidTipMsg")
                .HasMaxLength(200)
                .HasColumnType("nvarchar");
            Property(p => p.ValidPattern)
                .HasColumnName(@"ValidPattern")
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
            Property(p => p.ValidErrorMsg)
                .HasColumnName(@"ValidErrorMsg")
                .HasMaxLength(200)
                .HasColumnType("nvarchar");
            Property(p => p.IsSystemField)
                .HasColumnName(@"IsSystemField")
                .HasColumnType("bit");
            Property(p => p.ItemOption)
                .HasColumnName(@"ItemOption")
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
            Property(p => p.HtmlTemplate)
                .HasColumnName(@"HtmlTemplate")
                .HasMaxLength(500)
                .HasColumnType("nvarchar");
            Property(p => p.FieldType)
                .HasColumnName(@"FieldType")
                .IsRequired()
                .HasColumnType("int");
            Property(p => p.Status)
                .HasColumnName(@"Status")
                .IsRequired()
                .HasColumnType("bit");
            // Association:
            HasMany(p => p.Models)
                .WithMany(c => c.ModelFields)
                .Map(manyToMany => manyToMany
                    .ToTable("ModelModelField", "dbo")
                    .MapLeftKey("ModelFieldId")
                    .MapRightKey("ModelId"));
        }
    }
}