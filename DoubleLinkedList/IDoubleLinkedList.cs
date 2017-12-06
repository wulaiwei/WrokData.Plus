// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：DoubleLinkedList
// 文件名：IDoubleLinkedList.cs
// 创建标识：吴来伟 2017-11-29 11:09
// 创建描述：
//  
// 修改标识：吴来伟2017-11-29 11:09
// 修改描述：
//  ------------------------------------------------------------------------------
namespace DoubleLinkedList
{
    /// <summary>
    /// IDoubleLinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDoubleLinkedList<T>
    {
        /// <summary>
        /// 节点之后
        /// </summary>
        /// <param name="item"></param>
        void AddAfter(T item);

        /// <summary>
        /// 节点之前
        /// </summary>
        /// <param name="item"></param>
        void AddBefore(T item);

        /// <summary>
        /// 插入指定位置之后
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        void InertAfter(T item, int index);

        /// <summary>
        /// 插入指定位置之前
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        void InsertBefore(T item, int index);

        /// <summary>
        /// 根据Index获取节点
        /// </summary>
        /// <param name="index"></param>
        DbNode<T> GetNodeByIndex(int index);

        /// <summary>
        /// 清空链表
        /// </summary>
        void Clear();

        /// <summary>
        /// 链表节点数量
        /// </summary>
        int Count();
    }
}