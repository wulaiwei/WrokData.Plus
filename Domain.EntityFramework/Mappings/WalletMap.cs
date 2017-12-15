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
    public class WalletMap : EntityTypeConfiguration<Wallet>
    {
        public WalletMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Wallet");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}