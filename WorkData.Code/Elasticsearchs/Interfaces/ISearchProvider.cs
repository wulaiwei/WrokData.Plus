// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：ISearchProvider.cs
// 创建标识：吴来伟 2018-01-10 14:47
// 创建描述：
//  
// 修改标识：吴来伟2018-01-10 14:47
// 修改描述：
//  ------------------------------------------------------------------------------

using Nest;

namespace WorkData.Code.Elasticsearchs.Interfaces
{
    /// <summary>
    /// ISearchProvider
    /// </summary>
    public interface ISearchProvider
    {
        /// <summary>
        /// SearchPage
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        ISearchResponse<T> SearchPage<T>
            (SearchRequest<T> searchRequest) where T : class;
    }
}