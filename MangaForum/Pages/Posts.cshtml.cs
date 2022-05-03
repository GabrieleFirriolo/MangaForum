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
        private readonly ILogger<PostsModel> _logger;

        public PostsModel(ILogger<PostsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
