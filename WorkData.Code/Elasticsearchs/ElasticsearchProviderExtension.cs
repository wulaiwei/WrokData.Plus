// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：ElasticsearchProviderExtension.cs
// 创建标识：吴来伟 2018-01-04 15:24
// 创建描述：
//  
// 修改标识：吴来伟2018-01-04 15:24
// 修改描述：
//  ------------------------------------------------------------------------------

using System;
using Nest;
using WorkData.Code.BusinessEntities;

namespace WorkData.Code.Elasticsearchs
{
    /// <summary>
    /// ElasticsearchProviderExtension
    /// </summary>
    public static class ElasticsearchProviderExtension
    {
        /// <summary>
        /// InitializeIndexMap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void InitializeIndexMap<T>(this IElasticClient client, string index) where T : class
        {
            var descriptor = new CreateIndexDescriptor(index)
                .Mappings(ms => ms
                    .Map<T>(m => m.AutoMap())
                );
            var response = client.CreateIndex(descriptor);

            if (!response.IsValid)
                throw new UserFriendlyException("新增Index:" + response.OriginalException.Message);
        }

        /// <summary>
        /// InitializeIndexMap
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="client"></param>
        /// <param name="index"></param>
        public static void InitializeIndexMap<T1, T2>(this IElasticClient client, string index)
            where T1 : class where T2 : class
        {
            var descriptor = new CreateIndexDescriptor(index)
                .Mappings(ms => ms
                    .Map<T1>(m => m.AutoMap())
                    .Map<T2>(m => m.AutoMap())
                );
            client.CreateIndex(descriptor);
        }
    }
}