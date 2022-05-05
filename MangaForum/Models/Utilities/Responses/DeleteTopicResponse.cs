using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models.Utilities.Responses
{
    public class DeleteTopicResponse : DefaultResponse
    {
        public ForumTopic deleted_topic { get; set; }
    }
}
