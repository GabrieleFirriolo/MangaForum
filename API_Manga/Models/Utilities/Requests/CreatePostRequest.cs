using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Requests
{
    public class CreatePostRequest
    {
        [Required]
        public ForumUser Creator { get; set; }
        [Required]
        public ForumTopic Topic { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
