// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：IIndexProvider.cs
// 创建标识：吴来伟 2018-01-10 14:46
// 创建描述：
//  
// 修改标识：吴来伟2018-01-10 14:46
// 修改描述：
//  ------------------------------------------------------------------------------
namespace WorkData.Code.Elasticsearchs.Interfaces
{
    /// <summary>
    /// IIndexProvider
    /// </summary>
    public interface IIndexProvider
    {
        /// <summary>
        /// index是否存在
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        bool IndexExists(string index);

        /// <summary>
        /// 创建index
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="index"></param>
        void Index<T>(T entity, string index) where T : class;

        //删除index
        void RemoveIndex(string index);
    }
}