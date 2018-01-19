// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Test
// 文件名：Person.cs
// 创建标识：吴来伟 2018-01-04 14:44
// 创建描述：
//  
// 修改标识：吴来伟2018-01-05 10:58
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using Nest;

#endregion

namespace WorkData.Test.TestEntity
{
    [ElasticsearchType(IdProperty = "key", Name = "person")]
    public class Person
    {
        [Number(DocValues = false, IgnoreMalformed = true, Coerce = true, Name = "id")]
        public int Id { get; set; }

        [String(Analyzer = "ik")]
        public string Name { get; set; }

        [Boolean(NullValue = false, Store = true, Name = "isManager")]
        public bool IsManager { get; set; }

        //[Date(Format = "MMddyyyy")]
        public DateTime CreateTime { get; set; }

        public string Description { get; set; }

        [String(Ignore = true)]
        public string Content { get; set; }

        [Nested]
        public List<Person> Childs { get; set; }
    }

}