using MangaForum.Data;
using MangaForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Pages
{
    public class PostsModel : PageModel
    {
        public readonly MangaIdentityDbContext _context;
        public PostsModel(MangaIdentityDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ForumPost post { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id==null)
            {
                return NotFound();
            }
            post = APICaller.GetPostById(id).Result.posts.First();
            return Page();
        }
    }
}
