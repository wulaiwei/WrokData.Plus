// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：WorkDataAutoMapper.cs
// 创建标识：吴来伟 2017-12-06 16:50
// 创建描述：
//  
// 修改标识：吴来伟2017-12-06 16:50
// 修改描述：
//  ------------------------------------------------------------------------------

using AutoMapper;

namespace WorkData.Code.AutoMapper
{
    /// <summary>
    /// WorkDataAutoMapper
    /// </summary>
    public static class WorkDataAutoMapperExtensions
    {
        /// <summary>
        /// MapTo
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T MapTo<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

        /// <summary>
        /// MapTo
        /// </summary>
        /// <typeparam name="TS"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static T MapTo<TS, T>(TS source, T destination)
        {
            return Mapper.Map(source, destination);
        }
    }
}