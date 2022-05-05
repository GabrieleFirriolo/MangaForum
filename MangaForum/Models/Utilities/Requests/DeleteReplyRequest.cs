using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Requests
{
    public class DeleteReplyRequest
    {
        [Required]
        public int id_Reply { get; set; }

    }
}
