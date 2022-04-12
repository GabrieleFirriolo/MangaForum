using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class Manga
    {
        [Required]
        public string Titolo { get; set; }
        [Required]
        public string Creator { get; set; }
        [Required]
        public DateTime AnnoPubblicazione { get; set; }
        [Required]

        public string Image { get; set; }
    }
}
