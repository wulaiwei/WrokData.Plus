// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData
// 文件名：Bootstrap.cs
// 创建标识：吴来伟 2017-11-22 17:44
// 创建描述：
//  
// 修改标识：吴来伟2017-11-30 17:50
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Reflection;
using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using WorkData.Dependency;

#endregion

namespace WorkData
{
    /// <summary>
    ///     初始化装载程序
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        ///     _isInit
        /// </summary>
        private static bool _isInit;

        /// <summary>
        ///     _iocManager
        /// </summary>
        public IIocManager IocManager { get; }

        /// <summary>
        ///     instance bootstrap
        /// </summary>
        /// <returns></returns>
        public static Bootstrap Instance()
        {
            return new Bootstrap();
        }


        /// <summary>
        ///     Bootstrap
        /// </summary>
        public Bootstrap() : this(Dependency.IocManager.Instance)
        {
        }

        /// <summary>
        ///     Bootstrap
        /// </summary>
        /// <param name="iocManager"></param>
        public Bootstrap(IIocManager iocManager)
        {
            IocManager = iocManager;
        }


        /// <summary>
        ///     初始化集成框架
        /// </summary>
        [STAThread]
        public void Initiate()
        {
            if (_isInit) return;
            var builder = new ContainerBuilder();
            // Add the configuration to the ConfigurationBuilder.
            var config = new ConfigurationBuilder();
            //set base path
            config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
            // config.AddJsonFile comes from Microsoft.Extensions.Configuration.Json
            // config.AddXmlFile comes from Microsoft.Extensions.Configuration.Xml
            config.AddJsonFile("Configs/modules.json");

            //register all assembly
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces();

            // Register the ConfigurationModule with Autofac.
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);

            IocManager.SetContainer(builder);

            _isInit = true;
        }
    }
}