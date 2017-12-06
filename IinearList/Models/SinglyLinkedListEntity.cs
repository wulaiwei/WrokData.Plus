// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：IinearList
// 文件名：SinglyLinkedListEntity.cs
// 创建标识：吴来伟 2017-11-22 14:44
// 创建描述：
//  
// 修改标识：吴来伟2017-11-22 14:44
// 修改描述：
//  ------------------------------------------------------------------------------
namespace IinearList.Models
{
    public class SinglyLinkedListEntity
    {
        public SinglyLinkedListEntity(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}