using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models
{
    public class ForumPost
    {
        [Key]
        public int id_Post { get; set; }
        [Required]
        public ForumUser Creator { get; set; }
        [Required]
        public ForumTopic Topic { get; set; }
        [Required]
        public List<ForumReply> Replies { get; set; }
    }
}
