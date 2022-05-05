using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Responses
{
    public class CreateTopicResponse : DefaultResponse
    {
        public ForumTopic topic { get; set; }
    }
}
