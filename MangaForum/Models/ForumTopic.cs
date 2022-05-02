using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class ForumTopic
    {
        [Required]
        public int Name { get; set; }
        [Required]
        public Manga Manga { get; set; }
    }
}