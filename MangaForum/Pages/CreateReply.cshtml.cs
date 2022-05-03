using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Pages
{
    public class CreateReplyModel : PageModel
    {
        private readonly ILogger<CreateReplyModel> _logger;

        public CreateReplyModel(ILogger<CreateReplyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
