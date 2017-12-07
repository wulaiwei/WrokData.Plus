// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.WebApi
// 文件名：ServerResponse.cs
// 创建标识：吴来伟 2017-12-07 16:55
// 创建描述：
//  
// 修改标识：吴来伟2017-12-07 16:55
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Runtime.Serialization;

#endregion

namespace WorkData.WebApi.ResponseExtensions.Response
{
    /// <summary>
    ///     接口返回值
    /// </summary>
    [DataContract]
    public class ServerResponse
    {
        /// <summary>
        ///     状态
        /// </summary>
        [DataMember]
        public bool Status { get; set; }

        /// <summary>
        ///     描述信息
        /// </summary>
        [DataMember]
        public string Message { get; set; }
    }

    /// <summary>
    ///     响应消息类
    /// </summary>
    [DataContract]
    public class ServerResponse<T> : ServerResponse
        where T : class
    {
        /// <summary>
        ///     业务数据对象
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }
}