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
                    EleTopics = new List<ForumTopic>();
                    List<KeyValuePair<int, ForumTopic>> mylist = new List<KeyValuePair<int, ForumTopic>>();
                    var templist = APICaller.GetAllTopics().Result;
                    foreach (var item in templist)
                    {
                        if (APICaller.GetPostOfTopic(item.id_Topic).Result.state)
                            mylist.Add(new KeyValuePair<int, ForumTopic>(APICaller.GetPostOfTopic(item.id_Topic).Result.posts.Count, item));

                    }
                    foreach (var topicrev in mylist.OrderByDescending(x => x.Key))
                    {
                        EleTopics.Add(topicrev.Value);
                    }
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
