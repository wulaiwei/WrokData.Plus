// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData
// 文件名：IocManager.cs
// 创建标识：吴来伟 2017-11-22 17:38
// 创建描述：
//  
// 修改标识：吴来伟2017-12-05 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;

#endregion

namespace WorkData.Dependency
{
    /// <summary>
    ///     IocManager
    /// </summary>
    public class IocManager : IIocManager
    {
        /// <summary>
        ///     ContainerBuilder
        /// </summary>
        public ContainerBuilder ContainerBuilder { get; set; }

        /// <summary>
        ///     IocContainer
        /// </summary>
        public static IContainer IocContainer { get; set; }

        /// <summary>
        ///     ServiceLocator
        /// </summary>
        public IServiceLocator ServiceLocatorCurrent { get; set; }

        /// <summary>
        ///     The Singleton instance.
        /// </summary>
        public static IocManager Instance { get; }

        /// <summary>
        ///     IocManager
        /// </summary>
        static IocManager()
        {
            Instance = new IocManager();
        }

        /// <summary>
        ///     SetContainer
        /// </summary>
        /// <param name="containerBuilder"></param>
        public void SetContainer(ContainerBuilder containerBuilder)
        {
            ContainerBuilder = containerBuilder;
            var container = ContainerBuilder.Build();
            IocContainer = container;

            //设置定位器
            ServiceLocatorCurrent = new AutofacServiceLocator(IocContainer);
        }

        /// <summary>
        ///     IocContainer
        /// </summary>
        IContainer IIocManager.IocContainer
        {
            get => IocContainer;
            set => IocContainer = value;
        }

        /// <summary>
        ///     resolve T by lifetime scope
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T Resolve<T>(ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.Resolve<T>();
        }

        /// <summary>
        ///     Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public T Resolve<T>(IEnumerable<Parameter> parameters, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }
            return scope.Resolve<T>(parameters);
        }

        /// <summary>
        ///     Resolve
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public T ResolveParameter<T>(Parameter[] parameters)
        {
            var scope = Scope();
            return scope.Resolve<T>(parameters);
        }

        /// <summary>
        ///     IsRegistered
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool IsRegistered<T>() where T : class
        {
            return IsRegistered(typeof(T));
        }

        /// <summary>
        ///     IsRegistered
        /// </summary>
        /// <param name="type"></param>
        /// <param name="scope"></param>
        /// <returns></returns>
        public bool IsRegistered(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                scope = Scope();
            }

            return scope.IsRegistered(type);
        }

        /// <summary>
        ///     release object lifetimescope
        /// </summary>
        /// <param name="obj"></param>
        public void Release(object obj)
        {
        }

        /// <summary>
        ///     create ILifetimeScope  from container
        /// </summary>
        /// <returns></returns>
        private static ILifetimeScope Scope()
        {
            return IocContainer.BeginLifetimeScope();
        }
    }
}