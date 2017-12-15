// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.WebApi
// 文件名：ResponseProvider.cs
// 创建标识：吴来伟 2017-12-07 16:55
// 创建描述：
//
// 修改标识：吴来伟2017-12-07 16:55
// 修改描述：
//  ------------------------------------------------------------------------------

#region

#endregion

namespace WorkData.WebApi.ResponseExtensions.Response
{
    public static class ResponseProvider
    {
        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse Success(string msg = null)
        {
            var result = new ServerResponse { Status = true, Message = msg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="status">状态:0 -成功 其它 失败</param>
        /// <param name="errMsg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse Error(string errMsg, bool status = false)
        {
            var result = new ServerResponse { Status = status, Message = errMsg };
            return result;
        }

        /// <summary>
        ///     响应消息封装类
        /// </summary>
        /// <param name="data">业务数据</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Success<T>(T data, string msg = null) where T : class, new()
        {
            var result = new ServerResponse<T> { Data = data, Status = true, Message = msg };

            return result;
        }

        /// <summary>
        ///     Http 响应消息封装类
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public static ServerResponse<T> Error<T>(string msg = null) where T : class, new()
        {
            var result = new ServerResponse<T> { Data = null, Status = false, Message = msg };

            return result;
        }
    }
}