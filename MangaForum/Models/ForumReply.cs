
using MangaForum.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MangaForum.Models
{
    public class ForumReply
    {
        public int id_Reply { get; set; }
        public ForumUser Creator { get; set; }
        public string Reply { get; set; }
        public DateTime ReplyDate { get; set; }
        public ForumPost Post { get; set; }
    }
}