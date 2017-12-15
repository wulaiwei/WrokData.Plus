// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.EntityFramework
// 文件名：WalletMap.cs
// 创建标识：吴来伟 2017-12-06 11:37
// 创建描述：
//
// 修改标识：吴来伟2017-12-06 11:37
// 修改描述：
//  ------------------------------------------------------------------------------

using Domain.Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.EntityFramework.Mappings
{
    public class DoMap : EntityTypeConfiguration<Do>
    {
        public DoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Id)
                .HasMaxLength(50);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Do");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}