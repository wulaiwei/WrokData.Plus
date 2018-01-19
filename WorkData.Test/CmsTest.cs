using System;
using AutoFixture;
using CommonServiceLocator;
using Domain.Core.Contents;
using Domain.EntityFramework.EntityFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nest;
using WorkData.Service;
using WorkData.Service.Contents.Models;

namespace WorkData.Test
{
    [TestClass]
    public class CmsTest: BaseTest
    {
        [TestMethod]
        public void AddModel()
        {
            var modelService = ServiceLocator.GetInstance<IModelService>();

            using (var unitofWork = ResolveUnitOfWork())
            {
                var model = FixtureData.Build<Model>()
                    .With(x => x.ModelFields, null)
                    .With(x => x.Categories, null)
                    .With(x => x.Contents, null)
                    .Create();

                var id= modelService.AddModelGetId(model);
                unitofWork.Complate();
            }
        }
    }
}
