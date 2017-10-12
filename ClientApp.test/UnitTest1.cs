using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProduseEco.Controllers;
using ProduseEco.ViewModel;
using Moq;
using ClientApp.Infrastructure;
using ClientApp.Infrastructure.Models;

namespace ClientApp.test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testrepo = new TestClientRepository();
            ClientController controller = new ClientController(testrepo);
            int nrofcl = testrepo.nrOfClient;
            ClientViewModel client = new ClientViewModel()
            {
                Username = "Test",
                Password = "Test"
            };
            controller.AddOrEdit(client);

            Assert.AreEqual(nrofcl + 1, testrepo.nrOfClient);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var testrepo = new TestClientRepository();
            ClientController controller = new ClientController(testrepo);
            int nrofcl = testrepo.nrOfClient;
            ClientViewModel client = new ClientViewModel()
            {
                Username = "Username",
                Password = "Test"
            };
            controller.AddOrEdit(client);

            Assert.AreEqual(nrofcl, testrepo.nrOfClient);
        }

        [TestMethod]
        public void TestMethod3()
        {
            int nrclientiInitial = 0; int nrCurrent = 0;
            Mock<IClientRepository> clientRepoMocked = new Mock<IClientRepository>();
            clientRepoMocked.Setup(x => x.FindByUsername(It.IsAny<string>())).Returns(() => null);
            clientRepoMocked.Setup(x => x.Add(It.IsAny<Infrastructure.Models.Client>())).Callback((Infrastructure.Models.Client c) => {
                nrCurrent++;
            });
            ClientController controller = new ClientController(clientRepoMocked.Object);
            ClientViewModel client = new ClientViewModel()
            {
                Username = "Username",
                Password = "Test"
            };
            controller.AddOrEdit(client);

            Assert.AreEqual(nrCurrent, nrclientiInitial+1);
        }

        [TestMethod]
        public void TestMethod4()
        {
            int nrclientiInitial = 0; int nrCurrent = 0;
            Mock<IClientRepository> clientRepoMocked = new Mock<IClientRepository>();
            clientRepoMocked.Setup(x => x.FindByUsername(It.IsAny<string>())).Returns(() => new Client());
            clientRepoMocked.Setup(x => x.Add(It.IsAny<Client>())).Callback((Client c) => {
                nrCurrent++;
            });
            ClientController controller = new ClientController(clientRepoMocked.Object);
            ClientViewModel client = new ClientViewModel()
            {
                Username = "Username",
                Password = "Test"
            };
            controller.AddOrEdit(client);

            Assert.AreEqual(nrCurrent, nrclientiInitial);
        }
    }
}
