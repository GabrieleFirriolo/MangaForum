using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class Manga
    {
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