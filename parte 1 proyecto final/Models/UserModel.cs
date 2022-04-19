using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace parte_1_proyecto_final.Models
{
    public class UserModel
    {

        public int UserId { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Passw { get; set; }


    }
}
