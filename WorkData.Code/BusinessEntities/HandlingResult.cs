// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：HandlingResult.cs
// 创建标识：吴来伟 2017-12-07 11:14
// 创建描述：
//  
// 修改标识：吴来伟2017-12-07 11:18
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Net;

#endregion

namespace WorkData.Code.BusinessEntities
{
    /// <summary>
    ///     处理结果
    /// </summary>
    public class HandlingResult
    {
        /// <summary>
        ///     获取或设置处理结果，默认值为true。
        /// </summary>
        public bool Successed { get; set; }

        /// <summary>
        ///     获取或设置处理消息，默认值为空。
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     StatusCode
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        ///     获取或设置处理其他结果，默认值为null。
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        ///     构造函数
        /// </summary>
        public HandlingResult()
        {
            Successed = true;
            Message = string.Empty;
            Result = null;
        }
    }
}