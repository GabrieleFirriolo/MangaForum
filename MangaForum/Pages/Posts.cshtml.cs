using MangaForum.Data;
using MangaForum.Models;
using MangaForum.Models.Utilities.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Pages
{
    public class PostsModel : PageModel
    {
        public readonly MangaIdentityDbContext _context;
        public PostsModel(MangaIdentityDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public ForumTopic topic { get; set; }
        [BindProperty]
        public ForumPost post { get; set; }
        [BindProperty]
        public ForumReply reply { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id==null)
            {
                return NotFound();
            }
            post = APICaller.GetPostById(id).Result.posts.First();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(string delpost,string delreply)
        {
            if (delreply != null)
            {
                reply = APICaller.GetRelyById(reply.id_Reply).Result.reply;
                await APICaller.DeleteReply(new DeleteReplyRequest { id_Reply = reply.id_Reply });
                return Page();
            }
            else if(delpost != null)
            {
                post = APICaller.GetPostById(post.id_Post).Result.posts.First();
                await APICaller.DeleteTopic(new DeleteTopicRequest { id_Topic = post.Topic.id_Topic});
                return RedirectToPage("./Index");
            }
            return NotFound();
        }
    }
}
