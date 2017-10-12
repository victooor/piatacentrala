using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Infrastructure.Models;


namespace ClientApp.Infrastructure
{
   public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client FindById(int Id);
        void Add(Client c);
        void Edit(Client c);
        void Remove(int Id);
        Client FindByUsername(string username);
        Client FindByUsernameAndPass(string username, string password);
    }
}
 