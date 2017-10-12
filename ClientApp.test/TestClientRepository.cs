using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Infrastructure;
using ClientApp.Infrastructure.Models;

namespace ClientApp.test
{
    class TestClientRepository : IClientRepository
    {
        public int nrOfClient = 1000;

        public void Add(Client c)
        {
            nrOfClient++;
        }

        public void Edit(Client c)
        {
            throw new NotImplementedException();
        }

        public Client FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public Client FindByUsername(string username)
        {
            if (username == "Test")
                return null;
            else
                return new Client();
        }

        public Client FindByUsernameAndPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            throw new NotImplementedException();
        }

        public void Remove(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
