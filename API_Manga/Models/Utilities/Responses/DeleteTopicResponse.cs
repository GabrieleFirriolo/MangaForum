using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class DeleteTopicResponse : DefaultResponse
    {
        public ForumTopic deleted_topic { get; set; }
    }
}
