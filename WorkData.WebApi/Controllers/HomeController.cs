using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkData.Code.BusinessEntities;
using WorkData.WebApi.Models;

namespace WorkData.WebApi.Controllers
{
    public class HomeController : WorkDataBaseApiController
    {
        [HttpGet]
        public List<Class1> GetAll()
        {
            return new List<Class1>()
            {
                new Class1(){Name="123"},
                new Class1(){Name="123"}
            };
        }
    }
}
