using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class DeletePostResponse : DefaultResponse
    {
        public ForumPost deleted_post { get; set; }
    }
}
