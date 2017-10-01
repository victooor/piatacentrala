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
        public string Nume { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Prenume { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Oras { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Adresa { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public Nullable<int> Telefon { get; set; }
        [Required(ErrorMessage = "This field is required.")]

        public string Username { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}