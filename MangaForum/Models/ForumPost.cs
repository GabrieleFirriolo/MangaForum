using MangaForum.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class ForumPost
    {
        public int id_Post { get; set; }
        public ForumUser Creator { get; set; }
        public ForumTopic Topic { get; set; }
        public List<ForumReply> Replies { get; set; }
    }
}