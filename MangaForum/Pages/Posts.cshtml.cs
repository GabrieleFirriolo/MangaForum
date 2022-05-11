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
        public async Task<IActionResult> OnPostAsync(int id,string delpost,string delreply,string modreply)
        {
            if (delreply != null)
            {
                reply = APICaller.GetReplyById(reply.id_Reply).Result.reply;
                await APICaller.DeleteReply(new DeleteReplyRequest { id_Reply = reply.id_Reply });
                post = APICaller.GetPostById(id).Result.posts.First();


                return Page();
            }
            else if(delpost != null)
            {
                post = APICaller.GetPostById(post.id_Post).Result.posts.First();
                await APICaller.DeletePost(new DeletePostRequest { id_Post = post.id_Post});
                return Redirect("./Index");               
            }
            else if (modreply != null)
            {
                reply = APICaller.GetReplyById(reply.id_Reply).Result.reply;
                return Redirect($"./ModReply?id={reply.id_Reply}");


            }
            return NotFound();
        }
    }
}
