﻿// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.WebApi
// 文件名：WorkDataBaseApiController.cs
// 创建标识：吴来伟 2017-12-07 13:55
// 创建描述：
//  
// 修改标识：吴来伟2017-12-07 14:14
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System.Web.Http;
using Autofac.Extras.DynamicProxy;
using WorkData.Infrastructure.UnitOfWorks;
using WorkData.WebApi.ResponseExtensions.Filters;

#endregion

namespace WorkData.WebApi.Controllers
{
    /// <summary>
    ///     WorkDataBaseApiController
    /// </summary>
    [Intercept(typeof(UnitOfWorkInterceptor))]
    [BaseApiExceptionFilter]
    public class WorkDataBaseApiController : ApiController
    {
    }
}