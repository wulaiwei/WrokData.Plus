// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：SinglyLinkedList
// 文件名：SinglyLinkedListModule.cs
// 创建标识：吴来伟 2017-11-22 15:02
// 创建描述：
//  
// 修改标识：吴来伟2017-11-22 15:02
// 修改描述：
//  ------------------------------------------------------------------------------

using Autofac;

namespace SinglyLinkedList
{
    public class SinglyLinkedListModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //InstancePerDependency 每次新的实例
            //SingleInstance 单例
            builder.RegisterGeneric(typeof(SinglyLinkedList<>))
                .As(typeof(ISinglyLinkedList<>)).InstancePerDependency();
        }
    }
}