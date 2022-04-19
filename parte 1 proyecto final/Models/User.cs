using System;
using System.Collections.Generic;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class User
    {
        public User()
        {
            News = new HashSet<News>();
        }

        public int UserId { get; set; }
        public int? UserTypeId { get; set; }
        public string Email { get; set; }
        public string Passw { get; set; }

        public virtual UserType UserType { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
