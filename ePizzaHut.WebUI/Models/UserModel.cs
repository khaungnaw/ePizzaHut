using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ePizzaHut.WebUI.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Password is requred")]
        public string Password { get; set; }
        
        [Compare("Password"),Required(ErrorMessage = "Compare password do not match")]
        public string ConfirmationPassword { get; set; }

        [Required(ErrorMessage = "Phonen Number is required")]
        public string PhoneNumber { get; set; }
    }
}
