using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class Country
    {
        public Country()
        {
            News = new HashSet<News>();
        }

        public int CountryId { get; set; }
        [Display(Name = "Country Name")]
        [Required(ErrorMessage = "This field is required")]
        [StringLength(25, ErrorMessage = "The Country limit is 25")]
        public string Country1 { get; set; }

        public virtual ICollection<News> News { get; set; }
    }
}
