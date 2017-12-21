// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：DomainCoreModule.cs
// 创建标识：吴来伟 2017-12-19 17:03
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 17:03
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using Domain.Core.WorkDataSessionExtensions;
using WorkData.Code.Sessions;
using WorkData.Extensions.Modules;

namespace Domain.Core
{
    public class DomainCoreModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkDataSessionExtension>()
                .As<IWorkDataSession>(); 
        }
    }
}