// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：AuditRuleExtend.cs
// 创建标识：吴来伟 2018-01-19 10:11
// 创建描述：
//  
// 修改标识：吴来伟2018-01-19 10:11
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.Entity;
using WorkData.Code.Entities.BaseInterfaces;

namespace Domain.EntityFramework.AuditRules
{
    /// <summary>
    /// AuditRuleExtend
    /// </summary>
    public static class AuditRuleExtend
    {
        /// <summary>
        /// AuditRuleConfigs
        /// </summary>
        public static readonly List<AuditRuleConfig> AuditRuleConfigs;

        static AuditRuleExtend()
        {
            AuditRuleConfigs = new List<AuditRuleConfig>();
            Init();
        }

        public static void Init()
        {

        }
    }
}