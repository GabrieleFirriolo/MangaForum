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
        public int Id { get; set; }
        [BindProperty]
        public List<ForumPost> ElePosts { get; set; }

        public async Task<IActionResult> OnGet(int id, string SearchUser, string Ordina)
        {
            if (SearchUser != null)
            {
                ElePosts = APICaller.GetPostOfTopic(id).Result.posts;
                var list = ElePosts.Where(x => x.Creator.Nome.ToLower().Trim() == SearchUser.ToLower().Trim()).ToList();
                ElePosts = list;
                return Page();
            }else if( Ordina != null)
            {
                
                ElePosts = APICaller.GetPostOfTopic(id).Result.posts;
                var list = ElePosts.OrderBy(x => x.Replies.Count).ToList();
                ElePosts = list;
                return Page();
            }
            try
            {
                ElePosts = APICaller.GetPostOfTopic(id).Result.posts;
                
            }
            catch (Exception ex)
            {
                return Redirect("/Error");

            }
            return Page();
        }


    }
}
