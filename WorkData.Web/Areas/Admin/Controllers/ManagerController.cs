// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Web
// 文件名：ManagerController.cs
// 创建标识：吴来伟 2017-12-26 15:56
// 创建描述：
//  
// 修改标识：吴来伟2017-12-26 15:59
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Web.Mvc;
using WorkData.Web.Controllers;

#endregion

namespace WorkData.Web.Areas.Admin.Controllers
{
    public class ManagerController : WorkDataBaseController
    {
        /// <summary>
        /// 主视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}