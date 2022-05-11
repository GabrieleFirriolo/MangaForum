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
        public bool check = false;

        public async Task<IActionResult> OnGet(int id, string SearchUser, string Ordina)
        {
            var userid = APICaller.GetUserByEmail(User.Identity.Name).Result.user.id_User;
            if (APICaller.GetPostOfUser(userid).Result.state)
            {
                var eleposts = APICaller.GetPostOfTopic(id).Result.posts.Where(x => x.Topic.id_Topic == id).ToList();
                List<KeyValuePair<DateTime, ForumPost>> mylist2 = new List<KeyValuePair<DateTime, ForumPost>>();
                List<ForumPost> result = new List<ForumPost>();
                foreach (var item in eleposts)
                {
                    if (item.Replies != null)
                        mylist2.Add(new KeyValuePair<DateTime, ForumPost>(item.Replies.OrderBy(x => x.ReplyDate).First().ReplyDate, item));
                }
                foreach (var lastpost in mylist2.OrderBy(x => x.Key))
                {
                    result.Add(lastpost.Value);
                }
                if (result.First().Creator.id_User == userid)
                {
                    check = true;
                }

            }
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
