// ------------------------------------------------------------------------------
// Copyright  吴来伟个人 版权所有。
// 项目名：WorkData.Service
// 文件名：WalletService.cs
// 创建标识：吴来伟 2017-12-07 19:32
// 创建描述：
//
// 修改标识：吴来伟2017-12-12 18:01
// 修改描述：
//  ------------------------------------------------------------------------------

#region

using Domain.Core;
using System;
using System.Globalization;
using System.Linq;
using WorkData.Infrastructure.Repositories;

#endregion

namespace WorkData.Service
{
    public class DoService : WorkDataBaseService, IDoService
    {
        private readonly IBaseRepository<Do, string> _rep;

        public DoService(IBaseRepository<Do, string> rep)
        {
            _rep = rep;
        }

        public void GetAll()
        {
            var reslut = _rep.GetAll().ToList();
            var do1 = new Do()
            {
                Id = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                Name = "world"
            };
            _rep.Insert(do1);
        }
    }
}