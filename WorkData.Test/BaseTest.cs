using System;
using System.Data.Entity;
using System.Linq;
using AutoFixture;
using CommonServiceLocator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WorkData.Infrastructure.UnitOfWorks;
using WorkData.Service;

namespace WorkData.Test
{
    [TestClass]
    public class BaseTest
    {
        public Fixture FixtureData { get; set; }

        /// <summary>
        ///     Gets a reference to the <see cref="Bootstrap" /> instance.
        /// </summary>
        public static Bootstrap BootstrapWarpper { get; } = Bootstrap.Instance<WorkDataServiceModule>();

        public IServiceLocator ServiceLocator { get; set; }

        public BaseTest()
        {
            BootstrapWarpper.Initiate();
            ServiceLocator = BootstrapWarpper.IocManager.ServiceLocatorCurrent;

            FixtureData = new Fixture();

            #region 级联对象构建
            FixtureData.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => FixtureData.Behaviors.Remove(b));
            FixtureData.Behaviors.Add(new OmitOnRecursionBehavior());

            #endregion
        }

        /// <summary>
        /// ResolveUnitOfWork
        /// </summary>
        /// <returns></returns>
        public IUnitOfWorkCompleteHandle ResolveUnitOfWork() 
        {
            var  unitOfWorkManager = ServiceLocator.GetInstance<IUnitOfWorkManager>();
            return unitOfWorkManager.Begin();
        }
    }
}
