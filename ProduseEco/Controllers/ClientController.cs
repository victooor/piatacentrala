using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProduseEco.ViewModel;
using ClientApp.Infrastructure;
using ClientApp.Infrastructure.Models;

namespace ProduseEco.Controllers
{
    public class ClientController : Controller
    {
        private IClientRepository repository;

        public ClientController()
        {
            this.repository = new ClientRepository();
        }

        public ClientController(IClientRepository clientRepository)
        {
            this.repository = clientRepository;
        }

        [HttpGet]

        public ActionResult AddOrEdit(int Id=0 )
        {
            ClientViewModel clientModel = new ClientViewModel();
            return View(clientModel);
        }
        [HttpPost]
        public ActionResult AddOrEdit(ClientViewModel clientModel)
        {


            Client dbClient = repository.FindByUsername(clientModel.Username);
            if(dbClient != null) { 
                ViewBag.DuplicateMessage = "Username already exit.";
                return View("AddOrEdit", clientModel);
            }
            Client client = ClientViewModelToClient(clientModel);

            repository.Add(client);

            
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