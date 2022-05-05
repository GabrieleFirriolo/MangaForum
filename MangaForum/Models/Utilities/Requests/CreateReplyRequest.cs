using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Requests
{
    public class CreateReplyRequest
    {
        [Required]
        public int id_Creator { get; set; }
        [Required]
        public int id_Post { get; set; }
        [Required]
        public string Reply { get; set; }

    }
}
