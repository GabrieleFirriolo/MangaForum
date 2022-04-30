using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Utilities.Responses
{
    public class CreateTopicResponse : DefaultResponse
    {
        public ForumTopic topic { get; set; }
    }
}
