// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：SinglyLinkedList
// 文件名：SinglyLinkedList.cs
// 创建标识：吴来伟 2017-11-22 13:39
// 创建描述：
//  
// 修改标识：吴来伟2017-11-22 13:39
// 修改描述：
//  ------------------------------------------------------------------------------
using System;

namespace SinglyLinkedList
{
    public class SinglyLinkedList<T> : ISinglyLinkedList<T> where T : class
    {
        /// <summary>
        /// 节点数量
        /// </summary>
        public int NodeCount => this.Count();

        /// <summary>
        /// 头节点
        /// </summary>
        public Node<T> HeadNode { get; set; }

        /// <summary>
        /// 获取链表深度
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            var depth = 0;
            var p = HeadNode;
            if (p == null)
                return depth;

            //获取深度
            while (p!=null)
            {
                p = p.NextItem;
                depth++;
            }

            return depth;
        }

        /// <summary>
        /// 新增节点
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(T entity)
        {
            var node = new Node<T>(entity);
            if (HeadNode != null)
            {
                var prevNode = this.GetNodeByIndex(this.NodeCount - 1);
                prevNode.NextItem = node;
            }
            else
            {
                this.HeadNode = node;
            }
            return this.NodeCount;
        }

        /// <summary>
        /// 清空链表
        /// </summary>
        public void Clear()
        {
            HeadNode = null;
        }

        /// <summary>
        /// 根据Index获取节点（从0开始计数）
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Node<T> GetNodeByIndex(int index)
        {
            IndexBound(index);

            var node = this.HeadNode;
            for (var i = 0; i < index; i++)
            {
                node = node.NextItem;
            }
            return node;
        }

        /// <summary>
        /// 链表是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.HeadNode == null;
        }


        /// <summary>
        /// 插入指定位置
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        public void Insert(T entity, int index)
        {
            IndexBound(index);
            if (index==0)
            {
                if (this.HeadNode==null)
                {
                    HeadNode = new Node<T>(entity);
                }
                else
                {
                    var tempNode = new Node<T>(entity)
                    {
                        NextItem = this.HeadNode
                    };
                    this.HeadNode = tempNode;
                }
            }
             var node = GetNodeByIndex(index-1);
            var nowNode = new Node<T>(entity)
            {
                NextItem = node.NextItem
            };
            node.NextItem = nowNode;
        }

        /// <summary>
        /// 移除节点
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T RemoveNode(int index)
        {
            IndexBound(index);

            T entity;
            if (index==0)
            {
                entity = this.HeadNode.Item;
                this.HeadNode = null;
            }
            else
            {
                var tempNode = GetNodeByIndex(index-1);
                if (tempNode.NextItem==null)
                {
                    throw new Exception("超出索引");
                }
                var deleteNode = tempNode.NextItem;
                tempNode.NextItem = deleteNode.NextItem;

                entity = deleteNode.Item;
            }
            return entity;
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