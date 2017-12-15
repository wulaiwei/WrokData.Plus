// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.WebApi
// 文件名：ApiUowFilterAttribute.cs
// 创建标识：吴来伟 2017-12-14 17:45
// 创建描述：
//
// 修改标识：吴来伟2017-12-14 17:45
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WorkData.Infrastructure.UnitOfWorks;

namespace WorkData.WebApi.ResponseExtensions.Filters
{
    /// <summary>
    /// ApiUowFilterAttribute
    /// ActionFilterAttribute rely on System.Web.Http.Filters
    /// </summary>
    public class ApiUowFilterAttribute : ActionFilterAttribute
    {
        public const string UowHttpContextKey = "__ApiUnitOfWork";
        public IUnitOfWorkCompleteHandle UnitOfWorkCompleteHandle { get; set; }
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ApiUowFilterAttribute(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;
        }

        /// <summary>
        /// BaseApiActionFilterAttribute
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            UnitOfWorkCompleteHandle = _unitOfWorkManager.Begin();
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="actionExecutedContext"></param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            UnitOfWorkCompleteHandle.Complate();
        }
    }
}