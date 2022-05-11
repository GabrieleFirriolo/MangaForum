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
        public List<ForumTopic> EleTopics { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                EleTopics = new List<ForumTopic>();
                List<KeyValuePair<int,ForumTopic>> mylist = new List<KeyValuePair<int,ForumTopic>>();
                var templist = APICaller.GetAllTopics().Result;
                foreach (var item in templist)
                {
                    if(APICaller.GetPostOfTopic(item.id_Topic).Result.state)
                    mylist.Add(new KeyValuePair<int, ForumTopic>(APICaller.GetPostOfTopic(item.id_Topic).Result.posts.Count,item));

                }
                foreach (var topicrev in mylist.OrderByDescending(x => x.Key).Take(5))
                {
                    EleTopics.Add(topicrev.Value);
                }


                ElePosts = new List<ForumPost>();
                var temp = APICaller.GetAllPosts().Result;
                List<KeyValuePair<DateTime, ForumPost>> mylist2 = new List<KeyValuePair<DateTime, ForumPost>>();

                foreach (var item in temp)
                {
                    if(item.Replies!= null)
                    mylist2.Add(new KeyValuePair<DateTime, ForumPost>(item.Replies.OrderBy(x=>x.ReplyDate).First().ReplyDate, item));
                }
                foreach (var lastpost in mylist2.OrderByDescending(x => x.Key).Take(5))
                {
                    ElePosts.Add(lastpost.Value);
                }


            }
            catch (Exception ex)
            {
                return Redirect("/Error");

            }
            return Page();
        }
    }
}
