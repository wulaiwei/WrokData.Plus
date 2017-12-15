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

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
        /// StartupModule
        /// </summary>
        public Type StartupModule { get; set; }

        /// <summary>
        /// Instance
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

            InitCreateModuls();
            LoadModuls();

            #region Load Config
            //var autofacConfig = new ConfigurationBuilder();
            //autofacConfig.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
            //autofacConfig.AddJsonFile("Configs/modules.json");
            //newBuidler.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .AsImplementedInterfaces();
            //var module = new ConfigurationModule(autofacConfig.Build());
            //newBuidler.RegisterModule(module);
            #endregion

            _isInit = true;
        }

        public void InitCreateModuls()
        {
            var builder = new ContainerBuilder();
            var moduleTypes = new List<Type> { StartupModule };
            moduleTypes.AddRange(FindDependedModuleTypes(StartupModule));
            moduleTypes.Reverse();
            foreach (var moduleType in moduleTypes)
            {
                if (!IocManager.IocContainer.IsRegistered(moduleType))
                {
                    builder.RegisterType(moduleType).Named($"{moduleType}", typeof(WorkDataBaseModule));
                }
            }
            //update container
            IocManager.UpdateContainer(builder);
        }

        public void LoadModuls()
        {
            var builder = new ContainerBuilder();
            var moduleTypes = new List<Type> { StartupModule };
            moduleTypes.AddRange(FindDependedModuleTypes(StartupModule));
            //loadType.GetAll(x => typeof(WorkDataBaseModule).IsAssignableFrom(x));
            moduleTypes.Reverse();
            foreach (var moduleType in moduleTypes)
            {
                var item = IocManager.IocContainer.ResolveNamed($"{moduleType}", typeof(WorkDataBaseModule)) as WorkDataBaseModule;
                if (item != null)
                {
                    item.IocManager = IocManager;
                    builder.RegisterModule(item);
                }
            }
            //update container
            IocManager.UpdateContainer(builder);
        }

        /// <summary>
        /// Finds direct depended modules of a module (excluding given module).
        /// </summary>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            var list = new List<Type>();

            if (moduleType.GetTypeInfo().IsDefined(typeof(DependsOnAttribute), true))
            {
                var dependsOnAttributes = moduleType.GetTypeInfo().GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>();
                foreach (var dependsOnAttribute in dependsOnAttributes)
                {
                    foreach (var dependedModuleType in dependsOnAttribute.DependsOnModuleTypes)
                    {
                        list.Add(dependedModuleType);
                    }
                }
            }

            return list;
        }
    }
}