// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Domain.EntityFramework
// 文件名：BaseUserMap.cs
// 创建标识：吴来伟 2017-12-22 17:15
// 创建描述：
//
// 修改标识：吴来伟2017-12-22 17:16
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Domain.Core.Permissions.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

#endregion

namespace Domain.EntityFramework.Mappings.Permissions
{
    /// <summary>
    /// BaseUserMap
    /// </summary>
    public class BaseUserMap : EntityTypeConfiguration<BaseUser>
    {
        public BaseUserMap()
        {
            HasKey(t => t.Id);

            Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(t => t.Id)
                .HasMaxLength(128);

            Property(t => t.UserName)
                .HasMaxLength(200);

            ToTable("BaseUser");
            Property(t => t.Id).HasColumnName("Id");
        }
    }
}