using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class ReplyResponse : DefaultResponse
    {
        public List<ForumReply> replies { get; set; }
    }
}
