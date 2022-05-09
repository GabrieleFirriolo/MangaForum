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
    public class ElePostsModel : PageModel
    {
         
        public readonly MangaIdentityDbContext _context;
        public ElePostsModel(MangaIdentityDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public List<ForumPost> ElePosts { get; set; }
    
            public async Task<IActionResult> OnGet(int id)
            {
                try
                {
                    ElePosts = APICaller.GetPostOfTopic(id).Result.posts;
                ;
                }
                catch (Exception ex)
                {
                    return RedirectToPage("/Error");

                }
                return Page();
            }
        
    }
}
