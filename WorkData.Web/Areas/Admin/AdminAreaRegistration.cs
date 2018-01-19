// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Web
// 文件名：AdminAreaRegistration.cs
// 创建标识：吴来伟 2017-12-26 15:52
// 创建描述：
//  
// 修改标识：吴来伟2017-12-26 15:52
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Web.Mvc;

#endregion

namespace WorkData.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName => "Admin";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional}
            );
        }
    }
}