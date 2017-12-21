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
using System.Linq;
using WorkData.Code.Sessions;
using WorkData.Infrastructure.Repositories;

#endregion

namespace WorkData.Service
{
    public class WalletService : WorkDataBaseService,IWalletService
    {
        private readonly IBaseRepository<Wallet, int> _rep;
        private readonly IWorkDataSession _workDataSession;

        public WalletService(IBaseRepository<Wallet, int> rep, IWorkDataSession workDataSession)
        {
            _rep = rep;
            _workDataSession = workDataSession;
        }

        public void GetAll()
        {
            var ss = _workDataSession;
            var reslut = _rep.GetAll().ToList();

            var item = new Wallet
            {
                Name = "wulaiwei copat"
            };

            _rep.Insert(item);
        }
    }
}