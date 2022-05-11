using MangaForum.Areas;
using MangaForum.Data;
using MangaForum.Models;
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
    public class UserPageModel : PageModel
    {
        public readonly MangaIdentityDbContext _context;
        private readonly UserManager<ForumUser> _userManager;
        public UserPageModel(MangaIdentityDbContext context, UserManager<ForumUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        [BindProperty]
        public ForumUser ForumUser { get; set; }
        [BindProperty]
        public int Topics { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            int userid = _userManager.GetUserAsync(User).Result.id_User;
            if (!APICaller.GetPostOfUser(userid).Result.state)
            {
                Topics = 0;
                return Page();
            }

            var eleposts = APICaller.GetPostOfUser(id).Result.posts;
            var topics = APICaller.GetAllTopics().Result;
            foreach(var topic in topics)
            {
                foreach (var post in eleposts)
                {
                    if(post.Topic.id_Topic == topic.id_Topic)
                    {
                        Topics++;
                    }
                }
                 
            }
            ;
        
            ForumUser = APICaller.GetUserById(id).Result.user;
            return Page();
        }
        
    }
}
