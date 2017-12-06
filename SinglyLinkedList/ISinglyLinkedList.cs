// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：SinglyLinkedList
// 文件名：ISinglyLinkedList.cs
// 创建标识：吴来伟 2017-11-22 11:35
// 创建描述：
//  
// 修改标识：吴来伟2017-11-22 11:35
// 修改描述：
//  ------------------------------------------------------------------------------
namespace SinglyLinkedList
{
    /// <summary>
    /// 单链表
    /// </summary>
    public interface ISinglyLinkedList<T> where T:class
    {
        /// <summary>
        /// 节点数量
        /// </summary>
        int NodeCount { get;  }

        /// <summary>
        /// 头节点
        /// </summary>
        Node<T> HeadNode { get; set; }

        /// <summary>
        /// 统计数量
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        ///  新增并返回链表数量
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// 清空链表
        /// </summary>
        void Clear();

        /// <summary>
        /// 插入指定位置链表
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        void Insert(T entity,int index);

        /// <summary>
        /// 移除指定节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        T RemoveNode(int index);

        /// <summary>
        /// 根据index获取节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Node<T> GetNodeByIndex(int index);

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <returns></returns>
        bool IsEmpty();
    }
}