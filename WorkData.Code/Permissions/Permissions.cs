// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：Permissions.cs
// 创建标识：吴来伟 2017-12-22 10:04
// 创建描述：
//  
// 修改标识：吴来伟2017-12-22 10:04
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Permissions
{
    /// <summary>
    /// 数据权限
    /// </summary>
    public enum DataPermission
    {
        /// <summary>
        /// 没有权限（权限最高 存在此权限禁止其他设置全部失效）
        /// </summary>
        禁止 = -1,

        /// <summary>
        /// 全部数据
        /// </summary>
        全部 = 0,

        /// <summary>
        /// 用户所在公司数据（Member）
        /// </summary>
        所在公司,

        /// <summary>
        /// 用户所在部门数据 (Department)
        /// </summary>
        所在部门,

        /// <summary>
        ///  用户所在工作组数据 （UserGroup）
        /// </summary>
        所在工作组,

        /// <summary>
        /// 自己的数据 （CreateUserId）
        /// </summary>
        仅本人,

        /// <summary>
        /// 按详细设定的数据
        /// </summary>
        详细        
    }

    /// <summary>
    /// 数据权限类别
    /// </summary>
    public enum DataPermissionType
    {
        /// <summary>
        /// 主账号子账号类别
        /// </summary>
        主账号子账号=0,

        /// <summary>
        /// 基于角色
        /// </summary>
        角色
    }
}