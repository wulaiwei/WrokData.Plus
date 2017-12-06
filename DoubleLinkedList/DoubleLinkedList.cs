// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：DoubleLinkedList
// 文件名：DoubleLinkedList.cs
// 创建标识：吴来伟 2017-11-29 11:13
// 创建描述：
//  
// 修改标识：吴来伟2017-11-29 11:13
// 修改描述：
//  ------------------------------------------------------------------------------

using System;

namespace DoubleLinkedList
{
    /// <summary>
    /// DoubleLinkedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoubleLinkedList<T> : IDoubleLinkedList<T>
    {
        /// <summary>
        /// 节点数量
        /// </summary>
        public int NodeCount => this.Count();

        /// <summary>
        /// 头节点
        /// </summary>
        public DbNode<T> HeadNode { get; set; }

        /// <summary>
        /// AddAfter
        /// </summary>
        /// <param name="item"></param>
        public void AddAfter(T item)
        {
            var node = new DbNode<T>(item);
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
            }
            else
            {
                var pnode = GetNodeByIndex(NodeCount - 1);
                pnode.NextNode = node;
                node.PreNode = pnode;
            }
        }

        /// <summary>
        /// AddBefore
        /// </summary>
        /// <param name="item"></param>
        public void AddBefore(T item)
        {
            var node = new DbNode<T>(item);
            if (this.HeadNode == null)
            {
                this.HeadNode = node;
            }
            else
            {
                var pnode = GetNodeByIndex(NodeCount - 1);
                var preNode = pnode.PreNode;

                preNode.NextNode = node;
                node.PreNode = preNode;

                pnode.PreNode = node;
                node.NextNode = pnode;
            }
        }

        /// <summary>
        /// Inert
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"> from 0 begin</param>
        public void InertAfter(T item, int index)
        {
            var node = new DbNode<T>(item);
            if (index == 0)
            {
                if (this.HeadNode == null)
                {
                    this.HeadNode = node;
                }
                else
                {
                    var headNode = this.HeadNode;
                    node.NextNode = headNode;
                    headNode.PreNode = node;
                    this.HeadNode = node;
                }
            }
            else
            {
                var pnode = GetNodeByIndex(index);
                var nextNode = pnode.NextNode;
                pnode.NextNode = node;
                node.PreNode = pnode;

                if (nextNode == null)
                    return;
                node.NextNode = nextNode;
                nextNode.PreNode = node;
            }
        }

        /// <summary>
        /// 插入在队列之前
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void InsertBefore(T item, int index)
        {
            var node = new DbNode<T>(item);
            if (index == 0)
            {
                if (this.HeadNode == null)
                {
                    this.HeadNode = node;
                }
                else
                {
                    var headNode = this.HeadNode;
                    node.NextNode = headNode;
                    headNode.PreNode = node;
                    this.HeadNode = node;
                }
            }
            else
            {
            }
        }

        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            this.HeadNode = null;
        }

        /// <summary>
        /// GetNodeByIndex
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public DbNode<T> GetNodeByIndex(int index)
        {
            IndexBound(index);
            var node = this.HeadNode;
            for (var i = 0; i < index; i++)
            {
                node = node.NextNode;
            }
            return node;
        }

        public int Count()
        {
            var depth = 0;
            var p = HeadNode;
            if (p == null)
                return depth;

            //获取深度
            while (p != null)
            {
                p = p.NextNode;
                depth++;
            }

            return depth;
        }

        /// <summary>
        /// 索引界限判断
        /// </summary>
        /// <param name="index"></param>
        private void IndexBound(int index)
        {
            if (index < 0 || index > this.NodeCount)
            {
                throw new Exception("超出索引");
            }
        }
    }
}