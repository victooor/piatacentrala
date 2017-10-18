using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProduseEco.ViewModel
{
    public class ClientViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Va rugam sa introduceti numele.")]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Va rugam sa introduceti prenumele")]
        public string Prenume { get; set; }
        
        [Required(ErrorMessage = "Va rugam sa introduceti localitatea")]
        public string Oras { get; set; }
        

        [Required(ErrorMessage = "This field is required.")]
        public string Adresa { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Provided email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Provided phone number not valid")]
        public Nullable<int> Telefon { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage ="This field is required.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password cannot be shorter than 6 characters.")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}