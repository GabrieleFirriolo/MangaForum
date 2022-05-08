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
    public class CreateTopicModel : PageModel
    {
        public readonly MangaIdentityDbContext _context;
        public CreateTopicModel(MangaIdentityDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public ForumTopic Topic { get; set; }
        [BindProperty]
        public string FirstPostMessage {get;set;}
        public async Task<IActionResult> OnPostAsync()
        {

            Manga manga = APICaller.GetMangaByName(Topic.Manga.Title).Result.mangas.First();
            await APICaller.CreateTopic(new CreateTopicRequest { id_Manga = manga.id_Manga,Name = Topic.Name});
            var user =  _context.Users.Where(x => x.Email == User.Identity.Name).First();
            var topic = APICaller.GetTopicByName(Topic.Name).Result.topics.First().id_Topic;
            await APICaller.CreatePost(new CreatePostRequest { id_Creator = user.id_User, id_Topic = topic, Message = FirstPostMessage  });

            return RedirectToPage("./Index");
        }
    }
}
