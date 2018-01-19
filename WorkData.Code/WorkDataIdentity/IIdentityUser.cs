// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：Identity.cs
// 创建标识：吴来伟 2017-12-19 10:57
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 10:58
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Microsoft.AspNet.Identity;
using WorkData.Code.Entities;

namespace WorkData.Code.WorkDataIdentity
{
    /// <summary>
    /// Identity
    /// </summary>
    public interface IIdentityUser<out TPrimaryKey> :IUser<TPrimaryKey>
    {
    }
}