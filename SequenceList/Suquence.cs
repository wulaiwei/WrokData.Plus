// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：SequenceList
// 文件名：Suquence.cs
// 创建标识：吴来伟 2017-11-22 11:13
// 创建描述：
//  
// 修改标识：吴来伟2017-11-22 11:13
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Collections;

namespace SequenceList
{
    public class Suquence
    {
        /// <summary>
        /// Items
        /// </summary>
        public ArrayList Items { get; set; }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(object item)
        {
            Items.Add(item);
        }
    }
}