// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.EntityFramework
// 文件名：AuditableConfigs.cs
// 创建标识：吴来伟 2017-12-21 15:40
// 创建描述：
//  
// 修改标识：吴来伟2017-12-21 15:40
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections.Generic;
using WorkData.Code.Entities.BaseInterfaces;
using WorkData.Extensions.Types;

namespace WorkData.EntityFramework.Auditables
{
    public class AuditableConfigs
    {
        /// <summary>
        /// InitializedAuditables
        /// </summary>
        public static Dictionary<string, IAuditable> Auditables { get; set; }

        public ILoadType LoadType { get; set; }

        /// <summary>
        /// InitializedAuditables
        /// </summary>
        /// <param name="isReload"></param>
        public void InitializedAuditables(bool isReload=false)
        {
            if (Auditables==null || isReload)
            {
                Auditables= new Dictionary<string, IAuditable>();
            }
            var types = LoadType.GetAll(x => x.IsPublic && x.IsClass 
                                              && typeof(IAuditable).IsAssignableFrom(x));

        }
    }
}