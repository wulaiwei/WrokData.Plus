// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：DoubleLinkedList
// 文件名：DbNode.cs
// 创建标识：吴来伟 2017-11-29 11:00
// 创建描述：
//  
// 修改标识：吴来伟2017-11-29 11:00
// 修改描述：
//  ------------------------------------------------------------------------------
namespace DoubleLinkedList
{
    /// <summary>
    /// DbNode （双链表节点）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DbNode<T> 
    {
        /// <summary>
        /// Item
        /// </summary>
        public T Item { get; set; }

        /// <summary>
        /// PreNode
        /// </summary>
        public DbNode<T> PreNode { get; set; }

        /// <summary>
        /// NextNode
        /// </summary>
        public DbNode<T> NextNode { get; set; }

        /// <summary>
        /// DbNode
        /// </summary>
        /// <param name="item"></param>
        public DbNode(T item)
        {
            this.Item = item;
        }
    }
}