// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Web
// 文件名：WebUowFilterAttribute.cs
// 创建标识：吴来伟 2017-12-15 17:21
// 创建描述：
//
// 修改标识：吴来伟2017-12-15 17:21
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Web.Mvc;
using WorkData.Infrastructure.UnitOfWorks;
using FilterAttribute = System.Web.Http.Filters.FilterAttribute;

namespace WorkData.Web.Extensions.Filters
{
    /// <summary>
    /// WebUowFilterAttribute
    /// ActionFilterAttribute rely on System.Web.Mvc
    /// </summary>
    public class WebUowFilterAttribute : FilterAttribute, IActionFilter
    {
        public const string UowHttpContextKey = "__WebUnitOfWork";
        public IUnitOfWorkCompleteHandle UnitOfWorkCompleteHandle { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public WebUowFilterAttribute(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// Action之前
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UnitOfWorkCompleteHandle = _unitOfWorkManager.Begin();
        }

        /// <summary>
        /// Action之后
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            UnitOfWorkCompleteHandle.Complate();
        }
    }
}