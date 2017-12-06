// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。 
// 项目名：WorkData.EntityFramework
// 文件名：EfContextFactory.cs
// 创建标识：吴来伟 2017-12-05 9:15
// 创建描述：
//  
// 修改标识：吴来伟2017-12-05 10:13
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Data.Entity;
using Autofac;
using WorkData.Dependency;

#endregion

namespace WorkData.EntityFramework.UnitOfWorks
{
    /// <summary>
    ///     EfContextFactory
    /// </summary>
    public class EfContextFactory : IEfContextFactory
    {
        private readonly IResolver _resolver;

        public EfContextFactory(IResolver resolver)
        {
            _resolver = resolver;
        }

        /// <summary>
        ///     default current context
        /// </summary>
        /// <param name="dic"></param>
        /// <returns></returns>
        public TDbContext GetCurrentDbContext<TDbContext> (Dictionary<string, DbContext> dic) 
            where TDbContext : DbContext
        {
            return GetCurrentDbContext<TDbContext>(dic, "WorkData");
        }

        public TDbContext GetCurrentDbContext<TDbContext>( Dictionary<string, DbContext> dic, string conString)
            where TDbContext : DbContext
        {
            var dbContext = dic.ContainsKey(conString + "DbContext") ? dic[conString + "DbContext"] : null;
            try
            {
                if (dbContext != null)
                {
                    var con = dbContext.Database.Connection;
                    return (TDbContext)dbContext;
                }
            }
            catch (Exception)
            {
                dic.Remove(conString + "DbContext");
                //CallContext.FreeNamedDataSlot(conStringName + "DbContext");
            }

            dbContext = _resolver.ResolveParameter<TDbContext>(
                new NamedParameter("nameOrConnectionString", conString));

            //我们在创建一个，放到数据槽中去
            dic.Add(conString + "DbContext", dbContext);

            return (TDbContext)dbContext;
        }

    }
}