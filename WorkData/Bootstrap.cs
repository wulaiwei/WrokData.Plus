// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData
// 文件名：Bootstrap.cs
// 创建标识：吴来伟 2017-12-06 18:17
// 创建描述：
//  
// 修改标识：吴来伟2017-12-18 16:43
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using Autofac;
using WorkData.Dependency;
using WorkData.Extensions.Modules;

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
        public IIocManager IocManager { get; set; }

        /// <summary>
        ///     StartupModule
        /// </summary>
        public Type StartupModule { get; set; }

        /// <summary>
        ///     Instance
        /// </summary>
        /// <returns></returns>
        public static Bootstrap Instance<TStartupModule>() where TStartupModule : WorkDataBaseModule
        {
            return new Bootstrap(typeof(TStartupModule));
        }

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
        public Bootstrap(Type startupModule) : this(startupModule, Dependency.IocManager.Instance)
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
        ///     Bootstrap
        /// </summary>
        /// <param name="startupModule"></param>
        /// <param name="iocManager"></param>
        public Bootstrap(Type startupModule, IIocManager iocManager)
        {
            StartupModule = startupModule;
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
            //注入初始module
            builder.RegisterModule(new WorkDataModule());
            IocManager.SetContainer(builder);

            #region  modules register

            var workDataModuleManage = IocManager.Resolve<IWorkDataModuleManage>();
            workDataModuleManage.InitCreateModules(StartupModule);
            workDataModuleManage.LoadModules(StartupModule);

            #endregion

            _isInit = true;
        }
    }
}