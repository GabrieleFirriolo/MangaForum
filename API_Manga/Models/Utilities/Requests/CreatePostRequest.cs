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
        public int id_Creator { get; set; }
        [Required]
        public int id_Topic { get; set; }

        [Required]
        public string Message { get; set; }

    }
}
