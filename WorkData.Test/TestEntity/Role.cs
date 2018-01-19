// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Test
// 文件名：Role.cs
// 创建标识：吴来伟 2018-01-10 11:01
// 创建描述：
//  
// 修改标识：吴来伟2018-01-10 11:01
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Nest;

namespace WorkData.Test.TestEntity
{
    [ElasticsearchType(IdProperty = "Key", Name = "role")]
    public class Role
    {
        [String(Name = "key")]
        public string Key { get; set; }

        [String(Name ="name",Analyzer ="ik")]
        public string Name { get; set; }

        [String(Name="code",Analyzer ="ik")]
        public string Code { get; set; }

        public DateTime CreateTime { get; set; }

        public int S { get; set; }

        public bool B { get; set; }

        public decimal D { get; set; }

        public Guid G { get; set; }
    }
}