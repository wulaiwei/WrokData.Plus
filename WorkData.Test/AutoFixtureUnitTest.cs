// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Test
// 文件名：AutoFixtureUnitTest.cs
// 创建标识：吴来伟 2018-01-11 10:52
// 创建描述：
//  
// 修改标识：吴来伟2018-01-11 11:38
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Linq;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorkData.Test.TestEntity;

#endregion

namespace WorkData.Test
{
    [TestClass]
    public class AutoFixtureUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Fixture setup
            var fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var role = fixture.Create<Role>();
            var person = fixture.Create<Person>();
        }
    }
}