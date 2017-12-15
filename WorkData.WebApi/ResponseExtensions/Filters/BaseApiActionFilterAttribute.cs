// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.WebApi
// 文件名：WorkDataApiActionFilter.cs
// 创建标识：吴来伟 2017-12-07 17:14
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 17:14
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WorkData.WebApi.ResponseExtensions.Filters
{
    /// <summary>
    /// BaseApiActionFilterAttribute
    /// </summary>
    public class BaseApiActionFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// BaseApiActionFilterAttribute
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}