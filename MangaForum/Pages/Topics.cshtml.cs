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
        private readonly ILogger<TopicModel> _logger;

        public TopicModel(ILogger<TopicModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
