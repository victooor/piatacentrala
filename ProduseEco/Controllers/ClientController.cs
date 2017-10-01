using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProduseEco.Models;
using ProduseEco.ViewModel;


namespace ProduseEco.Controllers
{
    public class ClientController : Controller
    {
[HttpGet]

        public ActionResult AddOrEdit(int Id=0 )
        {
            ClientViewModel clientModel = new ClientViewModel();
            return View(clientModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(ClientViewModel clientModel)
        { 

            using (masterEntities2 dbModel = new masterEntities2())
            {  if (dbModel.Clients.Any(x => x.Username == clientModel.Username)) {

                    ViewBag.DuplicateMessage = "Username already exit.";
                    return View("AddOrEdit", clientModel);
                }
                Client client = ClientViewModelToClient(clientModel);
                dbModel.Clients.Add(client);
                dbModel.SaveChanges();

            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "registration successful";
            return View("AddOrEdit", new ClientViewModel());
        }

        private Client ClientViewModelToClient(ClientViewModel clientModel)
        {
            return new Client()
            {
                Adresa = clientModel.Adresa,
                Email = clientModel.Email,
                Nume = clientModel.Nume,
                Password = clientModel.Password,
                Prenume = clientModel.Prenume,
                Username = clientModel.Username,
                Oras = clientModel.Oras,
                Telefon = clientModel.Telefon
            };
        }
    }
}