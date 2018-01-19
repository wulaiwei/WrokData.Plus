// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：ElasticsearchSetting.cs
// 创建标识：吴来伟 2018-01-03 14:01
// 创建描述：
//  
// 修改标识：吴来伟2018-01-03 14:01
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Nest;

namespace WorkData.Code.Elasticsearchs
{
    /// <summary>
    /// ElasticsearchSetting
    /// </summary>
    public static class ElasticsearchSetting
    {
        /// <summary>
        /// Node
        /// </summary>
        public static Uri Node => new Uri("http://localhost:9200");

        //连接配置  
        public static ConnectionSettings ConnectionSettings =>
            new ConnectionSettings(Node)
            .DefaultIndex("defaultindex");
    }
}