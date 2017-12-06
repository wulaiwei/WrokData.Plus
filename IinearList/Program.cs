// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：IinearList
// 文件名：Program.cs
// 创建标识：吴来伟 2017-11-22 11:03
// 创建描述：
//  
// 修改标识：吴来伟2017-11-29 10:26
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using SinglyLinkedList;
using WorkData;

#endregion

namespace IinearList
{
    /// <summary>
    ///     线性表
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap Bootstrap { get; } = Bootstrap.Instance();

        private static void Main(string[] args)
        {
            //初始化程序
            Bootstrap.Initiate();
            var service = Bootstrap.IocManager.ServiceLocatorCurrent
                .GetInstance(typeof(ISinglyLinkedList<string>));
            //var res= Bootstrap.IocManager.Resolve<ISinglyLinkedList<string>>();

            //res.Add("1");
            //res.Add("2");
            //res.Add("3");
            //res.Add("4");

            //var data= res.HeadNode;


            Console.ReadKey();
        }
    }
}