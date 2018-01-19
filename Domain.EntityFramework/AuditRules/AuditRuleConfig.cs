// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.EntityFramework
// 文件名：AuditRuleConfig.cs
// 创建标识：吴来伟 2018-01-19 10:10
// 创建描述：
//  
// 修改标识：吴来伟2018-01-19 10:11
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using System.Data.Entity;

namespace Domain.EntityFramework.AuditRules
{
    public class AuditRuleConfig
    {
        public Action<object> AuditRuleAction;

        public EntityState EntityState { get; set; }
    }
}