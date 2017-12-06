// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.Code
// 文件名：WorkDataAutoMapperConfiguration.cs
// 创建标识：吴来伟 2017-12-06 17:06
// 创建描述：
//  
// 修改标识：吴来伟2017-12-06 17:06
// 修改描述：
//  ------------------------------------------------------------------------------

using AutoMapper;

namespace WorkData.Code.AutoMapper
{
    /// <summary>
    /// WorkDataAutoMapperConfiguration
    /// </summary>
    public class WorkDataAutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {

            });
        }
    }
}