// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：SinglyLinkedList
// 文件名：Node.cs
// 创建标识：吴来伟 2017-11-22 11:29
// 创建描述：
//  
// 修改标识：吴来伟2017-11-22 11:29
// 修改描述：
//  ------------------------------------------------------------------------------
namespace SinglyLinkedList
{
    /// <summary>
    /// Singly Linked List  Node   单链表节点（分为指针域 与  数据域）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T> where T :class
    {
        /// <summary>
        /// 数据域
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// 指针域
        /// </summary>
        public Node<T> NextItem { get; set; }

        /// <summary>
        /// Node
        /// </summary>
        /// <param name="item"></param>
        public Node(T item)
        {
            this.Item = item;
        }
    }
}