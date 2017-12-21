// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：IIdentityRole.cs
// 创建标识：吴来伟 2017-12-19 13:38
// 创建描述：
//  
// 修改标识：吴来伟2017-12-19 13:38
// 修改描述：
//  ------------------------------------------------------------------------------

using Microsoft.AspNet.Identity;

namespace WorkData.Code.WorkDataIdentity
{
    /// <summary>
    /// IIdentityRole
    /// </summary>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public interface IIdentityRole<out TPrimaryKey> :IRole<TPrimaryKey> where TPrimaryKey : class
    {
    }
}