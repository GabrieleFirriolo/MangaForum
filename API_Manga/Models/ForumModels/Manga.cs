using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models
{
    public class Manga
    {
        [Key]
        public int id_Manga { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Author { get; set; }
  
        [Required]
        public string Synopsis { get; set; }

    }

}
