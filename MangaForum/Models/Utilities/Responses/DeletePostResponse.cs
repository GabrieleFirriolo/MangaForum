using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Responses
{
    public class DeletePostResponse : DefaultResponse
    {
        public ForumPost deleted_post { get; set; }
    }
}
