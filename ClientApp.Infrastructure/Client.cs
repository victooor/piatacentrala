using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApp.Infrastructure.Models;

namespace ClientApp.Infrastructure
{
  public  class ClientContext : DbContext

    {

        public ClientContext()
            : base("name=masterEntities2")
        {
        }

      

        public virtual DbSet<Client> Clients { get; set; }
    }
}
