using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Requests
{
    public class CreateUserRequest
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public DateTime DataDiNascita { get; set; }
        [Required]
        public string Nazione { get; set; }
        [Required]
        public string Email { get; set; }
        public string UserImage { get; set; }
    }
}
