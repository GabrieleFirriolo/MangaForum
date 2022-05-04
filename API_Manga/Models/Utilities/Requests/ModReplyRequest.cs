using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Requests
{
    public class ModReplyRequest
    {
        [Required]
        public int id_Reply { get; set; }
        [Required]
        public string Reply { get; set; }

    }
}
