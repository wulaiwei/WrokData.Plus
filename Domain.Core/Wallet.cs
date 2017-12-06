// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：Domain.Core
// 文件名：Wallet.cs
// 创建标识：吴来伟 2017-12-06 16:30
// 创建描述：
//  
// 修改标识：吴来伟2017-12-06 16:33
// 修改描述：
//  ------------------------------------------------------------------------------


#region

using WorkData.Infrastructure.Entities;

#endregion

namespace Domain.Core
{
    /// <summary>
    /// Wallet
    /// </summary>
    public class Wallet : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}