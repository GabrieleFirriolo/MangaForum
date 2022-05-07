using MangaForum.Data;
using MangaForum.Models;
using MangaForum.Models.Utilities.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Pages
{
    [Authorize]
    public class CreatePostModel : PageModel
    {
        public readonly MangaIdentityDbContext _context;
        public CreatePostModel(MangaIdentityDbContext context)
        {
            this._context = context;
        }
      

    }
}

