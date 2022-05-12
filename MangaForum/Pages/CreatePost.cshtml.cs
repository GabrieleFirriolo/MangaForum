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
        [BindProperty]
        public List<ForumTopic> EleTopics { get; set; }
        [BindProperty]
        public ForumTopic Topic { get; set; }
        [BindProperty]
        public string FirstMessage { get; set; }


        public async Task<IActionResult> OnGet(int id)
        {
            try
            { EleTopics = APICaller.GetAllTopics().Result; }
            catch { return Redirect("/Error"); }

            if (id != 0)
            {
                Topic = APICaller.GetTopicById(id).Result.topic;
                return Page();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(Topic.id_Topic == 0 || FirstMessage == "")
            {
                EleTopics = APICaller.GetAllTopics().Result;
                return Page();
            }
            var user = _context.Users.Where(x => x.Email == User.Identity.Name).First();
            var post = await APICaller.CreatePost(new CreatePostRequest {id_Creator = user.id_User, id_Topic = Topic.id_Topic, Message = FirstMessage});

            if (post.state)
                return Redirect($"./Posts?id={post.post.id_Post}");
            else
                return Redirect("/Error");
        }

    }
}

