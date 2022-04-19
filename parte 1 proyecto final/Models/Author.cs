using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class Author
    {
        public Author()
        {
            News = new HashSet<News>();
        }

        public int AuthorId { get; set; }
      
        public string Author1 { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
