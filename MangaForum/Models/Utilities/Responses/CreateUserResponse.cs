using MangaForum.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Responses
{
    public class CreateUserResponse : DefaultResponse
    {
        public ForumUser user { get; set; }
    }
}
