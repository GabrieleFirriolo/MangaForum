using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models
{
    public class ForumUser 
    {
        [Key]
        [Required]
        public int id_User { get; set; }
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


    }
}
