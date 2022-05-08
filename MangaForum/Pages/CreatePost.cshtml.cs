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
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _context.Users.Where(x => x.Email == User.Identity.Name).First();
            await APICaller.CreatePost(new CreatePostRequest {id_Creator = user.id_User, id_Topic = Topic.id_Topic, Message = FirstMessage});


            return RedirectToPage("/Index");
        }

    }
}

