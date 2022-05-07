﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Areas
{
    public class ForumUser : IdentityUser
    {
        [Key]
        public int id_Creator { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cognome { get; set; }
        [Required]
        public DateTime DataDiNascita { get; set; }
        [Required]
        public string Nazione { get; set; }
        
        
    }
}
