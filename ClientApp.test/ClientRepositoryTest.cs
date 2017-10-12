using ClientApp.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.test
{
    [TestClass]
    class ClientRepositoryTest
    {
        ClientRepository Repo;
        [TestInitialize]
        public void TestSetup()
        {
            ClientInitializeDB db = new ClientInitializeDB();
            System.Data.Entity.Database.SetInitializer(db);
            Repo = new ClientRepository();
        }

        [TestMethod]
        public void IsRepositoryInitializeWithThValidNumberOfData()
        {
            var result = Repo.GetClients();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(2, numberOfRecords);
        }
    }
}
