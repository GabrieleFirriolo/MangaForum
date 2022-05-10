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
    public class TopicModel : PageModel
    {
         
        public readonly MangaIdentityDbContext _context;
        public TopicModel(MangaIdentityDbContext context)
        {
            this._context = context;
        }

        [BindProperty]
        public List<ForumTopic> EleTopics { get; set; }
    
            public async Task<IActionResult> OnGet(string Name,string Ordina)
            {
                if (Name != null)
                {
                    EleTopics = APICaller.GetAllTopics().Result;
                        
                 var list = EleTopics.Where(x => x.Name.ToLower().Trim().Contains(Name.ToLower().Trim())).ToList();
                    EleTopics = list;
                    return Page();
                }   
                else if (Ordina != null)
                {
                    //int count = 
                    //var list = EleTopics.OrderBy(x => APICaller.GetPostOfTopic(x.id_Topic).Result.posts.Count).ToList();
                    //EleTopics = list;
                    return Page();
                }
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
       

    }
}
