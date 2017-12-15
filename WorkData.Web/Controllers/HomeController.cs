using Domain.Core;
using System.Linq;
using System.Web.Mvc;
using WorkData.Infrastructure.Repositories;
using WorkData.Service;

namespace WorkData.Web.Controllers
{
    /// <summary>
    ///HomeController
    /// </summary>
    public class HomeController : WorkDataBaseController
    {
        private readonly IWalletService _walletService;
        private readonly IBaseRepository<Wallet, int> _rep;

        public HomeController(IWalletService walletService, IBaseRepository<Wallet, int> rep)
        {
            _walletService = walletService;
            _rep = rep;
        }

        // GET: Home
        public ActionResult Index()
        {
            _walletService.GetAll();
            var item = _rep.GetAll().ToList();
            return View();
        }
    }
}