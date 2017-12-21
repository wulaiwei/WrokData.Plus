using System.Collections.Generic;
using System.Web.Http;
using WorkData.Code.Sessions;
using WorkData.Service;
using WorkData.WebApi.Models;

namespace WorkData.WebApi.Controllers
{
    public class HomeController : WorkDataBaseApiController
    {
        private readonly IWalletService _walletService;
        private readonly IDoService _doService;

        public HomeController(IWalletService walletService, IDoService doService)
        {
            _walletService = walletService;
            _doService = doService;
        }

        [HttpGet]
        public List<Class1> GetAll()
        {
            var s = WorkDataSession;
            _walletService.GetAll();

            _doService.GetAll();
            return new List<Class1>()
            {
                new Class1(){Name="123"},
                new Class1(){Name="123"}
            };
        }
    }
}