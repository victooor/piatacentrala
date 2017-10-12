using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Infrastructure.Models;

namespace ClientApp.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        ClientContext context = new ClientContext();
        public void Add(Client c)
        {
            context.Clients.Add(c);
            context.SaveChanges();
        }

        public void Edit(Client c)
        {
            context.Entry(c).State = System.Data.Entity.EntityState.Modified;
        }

        public Client FindById(int Id)
        {
            var result = (from r in context.Clients where r.Id == Id select r).FirstOrDefault();
            return result;
        }

        public Client FindByUsername(string username)
        {
            var result = (from r in context.Clients where r.Username == username select r).FirstOrDefault();
            return result;
        }

        public Client FindByUsernameAndPass(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Clients;
        }

        public void Remove(int Id)
        {
            Client c = context.Clients.Find(Id);
            context.Clients.Remove(c);
            context.SaveChanges();
        }
    }
}
