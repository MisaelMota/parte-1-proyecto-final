using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace parte_1_proyecto_final.Models
{
    public partial class News
    {
        public int NewsId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public int? CountryId { get; set; }


        //[Required(ErrorMessage = "This field is required")]
        public int? AuthorId { get; set; }
       
        
        [Required(ErrorMessage = "This field is required")]
        public int? CategoryId { get; set; }
       
        [Required(ErrorMessage = "This field is required")]
        [StringLength(100, ErrorMessage = "The Category limit is 100")]
        public string Title { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(500, ErrorMessage = "The Category limit is 500")]
        public string Content { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Link { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string UrlToImage { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public DateTime? PublishedAt { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int? UserId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Country Country { get; set; }
        public virtual User User { get; set; }
    }
}
