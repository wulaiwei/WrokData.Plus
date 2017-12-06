// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：IinearList.UnitTest
// 文件名：UnitTest1.cs
// 创建标识：吴来伟 2017-11-28 16:40
// 创建描述：
//  
// 修改标识：吴来伟2017-11-28 16:40
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Linq;
using Domain.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglyLinkedList;
using WorkData;
using WorkData.EntityFramework;
using WorkData.Infrastructure.Repositories;
using WorkData.Infrastructure.UnitOfWorks;

#endregion

namespace IinearList.UnitTest
{
    /// <summary>
    /// 单链表 单元测试
    /// </summary>
    [TestClass]
    public class SinglyLinkedListUnitTest
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap Bootstrap { get; } = Bootstrap.Instance();

        private readonly ISinglyLinkedList<string> _singlyLinkedList;
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IBaseRepository<Wallet,int> _rep;

        public SinglyLinkedListUnitTest()
        {
            Bootstrap.Initiate();
            _singlyLinkedList = Bootstrap.IocManager
                .ServiceLocatorCurrent.GetInstance<ISinglyLinkedList<string>>();
            _unitOfWork= Bootstrap.IocManager
                .ServiceLocatorCurrent.GetInstance<IUnitOfWorkManager>();
            _rep = Bootstrap.IocManager
                .ServiceLocatorCurrent.GetInstance<IBaseRepository<Wallet, int>>();
        }


        /// <summary>
        /// Add
        /// </summary>
        [TestMethod]
        public void Add()
        {
            _singlyLinkedList.Add("1");
            //var current= _unitOfWork.Current;
            using (var begin = _unitOfWork.Begin())
            {
                //var head = _singlyLinkedList.HeadNode;
                // var data=_rep.GetAll().ToList();
                var waller = new Wallet()
                {
                    Name = "ahsdfasd123123"
                };
                _rep.Insert(waller);
                begin.Complate();
            }
            

        }

        /// <summary>
        /// GetNodeByIndex
        /// </summary>
        [TestMethod]
        public void GetNodeByIndex()
        {
            var index = 0;
            _singlyLinkedList.Add("1");
            _singlyLinkedList.Add("3");
            _singlyLinkedList.Add("2");
            var item = _singlyLinkedList.GetNodeByIndex(index);
            Console.WriteLine(item);
        }
    }
}