using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Requests
{
    public class CreateTopicRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int id_Manga { get; set; }
    }
}
