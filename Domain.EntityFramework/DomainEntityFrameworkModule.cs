// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：DomainEntityFrameworkModule.cs
// 创建标识：吴来伟 2017-12-06 15:12
// 创建描述：
//  
// 修改标识：吴来伟2017-12-06 15:12
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Data.Entity;
using Autofac;
using Domain.EntityFramework.EntityFramework;
using WorkData.EntityFramework;

namespace Domain.EntityFramework
{
    public class DomainEntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<EntityFrameworkModule>();

            builder.RegisterType<WorkDataContext>()
                .As<DbContext>();
        }
    }
}