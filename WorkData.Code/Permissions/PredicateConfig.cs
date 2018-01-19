// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：PredicateConfig.cs
// 创建标识：吴来伟 2017-12-22 15:21
// 创建描述：
//  
// 修改标识：吴来伟2017-12-22 15:21
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Permissions
{
    /// <summary>
    /// PredicateConfig
    /// </summary>
    public class PredicateConfig
    {
        /// <summary>
        /// 数据权限
        /// </summary>
        public DataPermission DataPermission { get; set; }

        /// <summary>
        /// 数据权限类别
        /// </summary>
        public DataPermissionType DataPermissionType { get; set; }


    }
}