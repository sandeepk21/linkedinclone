using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LinkedIn.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please Fill Required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please Fill Required")]
        public string password { get; set; }
    }
}