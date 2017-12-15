// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.WebApi
// 文件名：WorkDataBaseApiExceptionFilterAttribute.cs
// 创建标识：吴来伟 2017-12-07 17:18
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 17:18
// 修改描述：
//  ------------------------------------------------------------------------------

using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;
using WorkData.Code.BusinessEntities;
using WorkData.WebApi.ResponseExtensions.Response;

namespace WorkData.WebApi.ResponseExtensions.Filters
{
    /// <summary>
    /// BaseApiExceptionFilterAttribute
    /// </summary>
    public class BaseApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //业务异常
            if (context.Exception is UserFriendlyException)
            {
                context.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new ObjectContent<ServerResponse>(
                        ResponseProvider.Error(context.Exception.Message),
                        new JsonMediaTypeFormatter())
                };
            }
            //其它异常
            else
            {
                context.Response = new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError
                };
            }
        }
    }
}