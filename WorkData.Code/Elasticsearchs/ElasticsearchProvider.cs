// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：ElasticsearchProvider.cs
// 创建标识：吴来伟 2018-01-03 13:54
// 创建描述：
//  
// 修改标识：吴来伟2018-01-10 14:50
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Nest;
using WorkData.Code.BusinessEntities;
using WorkData.Code.Elasticsearchs.Interfaces;

#endregion

namespace WorkData.Code.Elasticsearchs
{
    /// <summary>
    ///     ElasticsearchProvider
    /// </summary>
    public class ElasticsearchProvider : IAliasProvider, IIndexProvider, ISearchProvider
    {
        #region IOC

        public ElasticClient ElasticClient { get; set; }

        /// <summary>
        ///     ElasticsearchProvider
        /// </summary>
        public ElasticsearchProvider()
        {
            ElasticClient = NullElasticClient.Instance;
        }

        #endregion

        /// <summary>
        ///     index 是否存在
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool IndexExists(string index)
        {
            var res = ElasticClient.IndexExists(index);
            return res.Exists;
        }

        /// <summary>
        ///     创建index  并新增数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public void Index<T>(T entity, string index) where T : class
        {
            if (!IndexExists(index))
            {
                ElasticClient.InitializeIndexMap<T>(index);
            }
            var response = ElasticClient.Index(entity,
                s => s.Index(index));

            if (!response.IsValid)
                throw new UserFriendlyException("新增数据失败:" + response.OriginalException.Message);
        }

        /// <summary>
        ///     删除index
        /// </summary>
        /// <param name="index"></param>
        public void RemoveIndex(string index)
        {
            ElasticClient.DeleteIndex(index);
        }

        /// <summary>
        ///     Alias 别名操作
        /// </summary>
        /// <param name="aliasRequest"></param>
        public IBulkAliasResponse Alias(IBulkAliasRequest aliasRequest)
        {
            var response = ElasticClient.Alias(aliasRequest);

            if (!response.IsValid)
                throw new UserFriendlyException("操作Alias失败:" +
                                                response.OriginalException.Message);
            return response;
        }


        /// <summary>
        ///     全文检索
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public ISearchResponse<T> SearchPage<T>
            (SearchRequest<T> searchRequest) where T : class
        {
            var resultList = ElasticClient
                .Search<T>(searchRequest);

            return resultList;
        }
    }
}