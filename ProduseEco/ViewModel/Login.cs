using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProduseEco.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}