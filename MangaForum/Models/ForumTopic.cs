using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class ForumTopic
    {
        public int id_Topic { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Manga Manga { get; set; }
    }
}