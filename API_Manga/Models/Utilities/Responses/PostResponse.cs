using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class PostResponse : DefaultResponse
    {
        public List<ForumPost> posts { get; set; }
    }
}
