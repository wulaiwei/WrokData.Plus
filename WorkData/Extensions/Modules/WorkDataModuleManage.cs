// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData
// 文件名：WorkDataModuleManage.cs
// 创建标识：吴来伟 2017-12-18 16:27
// 创建描述：
//  
// 修改标识：吴来伟2017-12-18 16:27
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using WorkData.Dependency;

namespace WorkData.Extensions.Modules
{
    public class WorkDataModuleManage: IWorkDataModuleManage
    {
        private readonly IIocManager _iocManager;

        public WorkDataModuleManage(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }

        /// <summary>
        /// InitCreateModules
        /// </summary>
        public void InitCreateModules(Type startupModule)
        {
            var builder = new ContainerBuilder();
            var moduleTypes = new List<Type> { startupModule };
            moduleTypes.AddRange(FindDependedModuleTypes(startupModule));
            moduleTypes.Reverse();
            foreach (var moduleType in moduleTypes)
            {
                if (!IocManager.IocContainer.IsRegistered(moduleType))
                {
                    builder.RegisterType(moduleType).Named($"{moduleType}", typeof(WorkDataBaseModule))
                        .PropertiesAutowired();
                }
            }
            //update container
            _iocManager.UpdateContainer(builder);
        }

        /// <summary>
        /// LoadModules
        /// </summary>
        /// <param name="startupModule"></param>
        public void LoadModules(Type startupModule)
        {
            var builder = new ContainerBuilder();
            var moduleTypes = new List<Type> { startupModule };
            moduleTypes.AddRange(FindDependedModuleTypes(startupModule));
            moduleTypes.Reverse();
            foreach (var moduleType in moduleTypes)
            {
                var item = IocManager.IocContainer
                    .ResolveNamed($"{moduleType}", typeof(WorkDataBaseModule))
                    as WorkDataBaseModule;
                if (item == null)
                    continue;
                item.IocManager = _iocManager;
                builder.RegisterModule(item);
            }
            _iocManager.UpdateContainer(builder);
        }

        /// <summary>
        /// Finds direct depended modules of a module (excluding given module).
        /// </summary>
        public static List<Type> FindDependedModuleTypes(Type moduleType)
        {
            var list = new List<Type>();

            if (!moduleType.GetTypeInfo().IsDefined(typeof(DependsOnAttribute), true))
                return list;
            var dependsOnAttributes = moduleType.GetTypeInfo()
                .GetCustomAttributes(typeof(DependsOnAttribute), true).Cast<DependsOnAttribute>();
            list.AddRange(
                dependsOnAttributes.SelectMany(
                    dependsOnAttribute => dependsOnAttribute.DependsOnModuleTypes));

            return list;
        }
    }
}