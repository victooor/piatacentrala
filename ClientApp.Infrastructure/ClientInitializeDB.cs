using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Infrastructure
{
   public class ClientInitializeDB : DropCreateDatabaseIfModelChanges<ClientContext>
    {
        protected override void Seed(ClientContext context)
        {
            base.Seed(context);
        }
    }
}
