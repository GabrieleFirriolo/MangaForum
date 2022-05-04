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
        private readonly ILogger<CreatePostModel> _logger;

        public CreatePostModel(ILogger<CreatePostModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
