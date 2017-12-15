// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.WebApi
// 文件名：WorkDataResponseHandler.cs
// 创建标识：吴来伟 2017-12-07 16:55
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 16:56
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using WorkData.WebApi.ResponseExtensions.Response;

#endregion

namespace WorkData.WebApi.ResponseExtensions
{
    public class WorkDataResponseHandler : DelegatingHandler
    {
        /// <summary>
        ///     SendAsync
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);
            //wapper response
            WapperServiceResponse(request, response);

            return response;
        }

        /// <summary>
        ///     WapperServiceResponse
        /// </summary>
        /// <param name="request"></param>
        /// <param name="response"></param>
        protected virtual void WapperServiceResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return;
            }

            object data;
            //无返回值
            if (!response.TryGetContentValue(out data) || data == null)
            {
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ObjectContent<ServerResponse>(
                    ResponseProvider.Success(), new JsonMediaTypeFormatter());
                return;
            }
            //错误情况
            if (data is ServerResponse)
            {
                return;
            }
            //构建返回值
            response.Content = new ObjectContent<ServerResponse>(
                ResponseProvider.Success(data), new JsonMediaTypeFormatter()
                );
        }
    }
}