// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：WorkDataCodeModule.cs
// 创建标识：吴来伟 2017-12-19 15:30
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 15:30
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;
using WorkData.Code.Sessions;
using WorkData.Extensions.Modules;

namespace WorkData.Code
{
    public class WorkDataCodeModule : WorkDataBaseModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkDataClaimsPrincipal>()
                .As<IWorkDataClaimsPrincipal>();

            builder.RegisterType<ClaimsSession>()
                .As<IWorkDataSession>();
        }
    }
}