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
    public class ClientControllerUnitTests
    {
        private Mock<IClientRepository> clientRepoMocked = new Mock<IClientRepository>();
        private int nrInitialClienti = 0;
        private int nrCurrentClienti = 0;

        [TestInitialize()]
        public void Initialize() {
            clientRepoMocked.Setup(x => x.Add(It.IsAny<Client>())).Callback((Client c) => {
                nrCurrentClienti++;
            });
        }

        [TestMethod]
        public void TestClientControllerAddsClientWhenClientDoesNotExist()
        {
            
            clientRepoMocked.Setup(x => x.FindByUsername("MissingClient")).Returns(() => null);
            
            ClientController controller = new ClientController(clientRepoMocked.Object);
            ClientViewModel client = new ClientViewModel()
            {
                Username = "MissingClient",
                Password = "Test"
            };
            controller.AddOrEdit(client);

            Assert.AreEqual(nrCurrentClienti, nrInitialClienti + 1);
        }

        [TestMethod]
        public void TestClientControllerDoesNotAddClientWhenClientExists()
        {

            clientRepoMocked.Setup(x => x.FindByUsername("ExistingClient")).Returns(() => new Client());
            
            ClientController controller = new ClientController(clientRepoMocked.Object);
            ClientViewModel client = new ClientViewModel()
            {
                Username = "ExistingClient",
                Password = "Test"
            };
            controller.AddOrEdit(client);

            Assert.AreEqual(nrCurrentClienti, nrInitialClienti);
        }
    }
}
