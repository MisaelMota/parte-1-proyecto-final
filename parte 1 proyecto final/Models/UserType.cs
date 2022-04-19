using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class UserType
    {
        public UserType()
        {
            Users = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string UserType1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
