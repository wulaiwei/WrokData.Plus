// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：NullElasticClient.cs
// 创建标识：吴来伟 2018-01-03 14:10
// 创建描述：
//  
// 修改标识：吴来伟2018-01-03 14:10
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;

namespace WorkData.Code.Elasticsearchs
{
    /// <summary>
    /// NullElasticClient
    /// </summary>
    public class NullElasticClient
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static ElasticClient Instance { get; } = 
            new ElasticClient(ElasticsearchSetting.ConnectionSettings);
    }
}