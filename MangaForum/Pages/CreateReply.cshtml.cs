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
    public class CreateReplyModel : PageModel
    {

        public readonly MangaIdentityDbContext _context;
        public CreateReplyModel(MangaIdentityDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public ForumReply Reply { get; set; }
        [BindProperty]
        public ForumPost Post { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var find =  APICaller.GetPostById(id).Result.posts.First();
            Post = find;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var user = _context.Users.Where(x => x.Email == User.Identity.Name).First();
            var reply = await APICaller.CreateReply(new CreateReplyRequest { id_Creator = user.id_User,id_Post = id, Reply = Reply.Reply });

            if (reply.state)
                return Redirect($"/Posts?id={id}");
            else
                return Redirect("/Error");
        }
       
    }
}
