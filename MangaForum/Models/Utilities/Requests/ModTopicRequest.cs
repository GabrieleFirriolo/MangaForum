using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Requests
{
    public class ModTopicRequest
    {
        [Required]
        public int id_Topic { get; set; }
        [Required]
        public string Name { get; set; }


    }
}
