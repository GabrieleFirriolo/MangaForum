using MangaForum.Areas;
using MangaForum.Data;
using MangaForum.Models;
using MangaForum.Models.Utilities.Requests;
using MangaForum.Models.Utilities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class ModTopicModel : PageModel
    {
        private readonly MangaIdentityDbContext _context;
        private readonly UserManager<ForumUser> _manager;
        public ModTopicModel(MangaIdentityDbContext context, UserManager<ForumUser> manager)
        {
            this._context = context;
            this._manager = manager;
            MangaTitleTrovato = "";
        }

        [BindProperty]
        public ForumTopic Topic { get; set; }
        [BindProperty]
        public Manga Manga { get; set; }
        [BindProperty]
        public string FirstPostMessage { get; set; }
        public string MangaTitleTrovato { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return Redirect("/Error");
            }
            var userid = APICaller.GetUserByEmail(User.Identity.Name).Result.user.id_User;
            if (!APICaller.GetPostOfUser(userid).Result.state)
            {
                return Redirect("/Error");
            }
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
                if (APICaller.GetTopicById(id).Result.state)
                {
                    Topic = APICaller.GetTopicById(id).Result.topic;
                    return Page();
                }
                else { return Redirect("/Error"); }
            }
            else
            {
                return Unauthorized();
            }






        }
        public bool check = false;
        public async Task<IActionResult> OnPostAsync()
        {
            CreateTopicResponse response = default;
            if (Topic.Name == "" || Topic.Name != null)
                response = await APICaller.ModTopic(new ModTopicRequest { id_Topic = Topic.id_Topic, Name = Topic.Name });
            else
                return Page();
            if (response.state)
                return Redirect($"/ElePosts?id={Topic.id_Topic}");
            else
                return Redirect("/Error");



        }
    }
}
