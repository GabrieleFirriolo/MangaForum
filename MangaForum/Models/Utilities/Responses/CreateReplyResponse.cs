using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Responses
{
    public class CreateReplyResponse : DefaultResponse
    {
        public ForumReply reply { get; set; }
    }
}
