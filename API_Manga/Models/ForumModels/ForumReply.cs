using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models
{
    public class ForumReply
    {
        [Key]
        public int id_Reply { get; set; }
        [Required]
        public ForumUser Creator { get; set; }
        [Required]
        public string Reply { get; set; }
        [Required]
        public DateTime ReplyDate { get; set; }
        [Required]
        public ForumPost Post { get; set; }

        public ForumReply(ForumUser creator, string reply,DateTime replydate,ForumPost post)
        {
            Creator = creator;
            Reply = reply;
            ReplyDate = replydate;
            Post = post;
        }
        public ForumReply(ForumUser creator, string reply, DateTime replydate)
        {
            Creator = creator;
            Reply = reply;
            ReplyDate = replydate;
        }
        public ForumReply()
        {

        }
    }
}
