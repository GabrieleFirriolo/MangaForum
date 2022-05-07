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
        public List<ForumTopic> EleTopics { get; set; }
        [BindProperty]
        public ForumTopic Topic { get; set; }
        [BindProperty]
        public ForumPost FirstPost {get;set;}
        public async Task<IActionResult> OnGet()
        {
            try
            {
                EleTopics = APICaller.GetAllTopics().Result;

            }
            catch (Exception ex)
            {
                return RedirectToPage("/Error");

            }
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var manga = APICaller.GetMangaByName(Topic.Manga.Title);
            await APICaller.CreateTopic(new CreateTopicRequest { id_Manga = manga.Id,Name = Topic.Name});
            await APICaller.CreatePost(new CreatePostRequest { id_Creator = APICaller.GetUserByEmail(User.Identity.Name).Result.user.id_Creator });

            return RedirectToPage("./Index");
        }
    }
}
