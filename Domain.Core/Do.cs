// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：Domain.Core
// 文件名：Do.cs
// 创建标识：吴来伟 2017-12-14 13:32
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 13:32
// 修改描述：
//  ------------------------------------------------------------------------------

using WorkData.Extensions.Modules;

namespace Domain.Core
{
    public class Do : IEntity<string>
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}