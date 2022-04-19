using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class Category
    {
        public Category()
        {
            News = new HashSet<News>();
        }

        public int CategoryId { get; set; }
        [Display(Name="Category Name")]
        [Required(ErrorMessage ="This field is required")]
        [StringLength(25,ErrorMessage ="The Category limit is 25")]
        public string Category1 { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
