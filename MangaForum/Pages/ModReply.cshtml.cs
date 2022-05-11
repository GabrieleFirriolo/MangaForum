using MangaForum.Areas;
using MangaForum.Data;
using MangaForum.Models;
using MangaForum.Models.Utilities.Requests;
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
    public class ModReplyModel : PageModel
    {

        public readonly MangaIdentityDbContext _context;
        private readonly UserManager<ForumUser> _userManager;
        public ModReplyModel(MangaIdentityDbContext context,UserManager<ForumUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        [BindProperty]
        public ForumReply Reply { get; set; }
        [BindProperty]
        public ForumPost Post { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            int user = _userManager.GetUserAsync(User).Result.id_User;
            var reply = APICaller.GetReplyById(id).Result.reply;
            var post = APICaller.GetPostByReplyId(id).Result.post;
            if (user == reply.Creator.id_User)
            {
                Reply = reply;
                Post = post; 
                return Page();
            }
            return Unauthorized();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var reply = await APICaller.ModReply(new ModReplyRequest {  id_Reply= Reply.id_Reply,Reply = Reply.Reply });
            if (reply.state)
                return Redirect($"/Posts?id={Post.id_Post}");
            else
                return Redirect("/Error");
        }
       
    }
}
