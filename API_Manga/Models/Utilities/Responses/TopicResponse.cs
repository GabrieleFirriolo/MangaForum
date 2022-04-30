using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class TopicResponse : DefaultResponse
    {
        public List<ForumTopic> topics { get; set; }
    }
}
