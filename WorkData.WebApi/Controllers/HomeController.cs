using System.Collections.Generic;
using System.Web.Http;
using WorkData.Code.Sessions;
using WorkData.Service;
using WorkData.Service.Contents.Models;
using WorkData.WebApi.Models;

namespace WorkData.WebApi.Controllers
{
    public class HomeController : WorkDataBaseApiController
    {


        private readonly IModelService _modelService;
        public HomeController(IModelService modelService)
        {

            _modelService = modelService;
        }
        [HttpGet]
        public List<Class1> GetAll()
        {
            return null;
        }
    }
}