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
    public class IndexModel : PageModel
    {
        public readonly MangaIdentityDbContext _context;
        public IndexModel(MangaIdentityDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public List<ForumPost> ElePosts { get; set; }
        [BindProperty]
        public int PostsInTopic { get; set; }

        [BindProperty]
        public List<ForumTopic> EleTopics { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                EleTopics = new List<ForumTopic>();
                EleTopics = APICaller.GetAllTopics().Result;
                
            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");

            }
            return Page();
        }
    }
}
