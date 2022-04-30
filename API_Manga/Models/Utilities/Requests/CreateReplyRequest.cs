using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Requests
{
    public class CreateReplyRequest
    {
        [Required]
        public ForumUser Creator { get; set; }
        [Required]
        public string Reply { get; set; }
        [Required]
        public DateTime ReplyDate { get; set; }
    }
}
