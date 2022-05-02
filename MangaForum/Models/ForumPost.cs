using MangaForum.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class ForumPost
    {
        public ForumUser Creator { get; set; }
        public ForumTopic Topic { get; set; }
    }
}