using API_Manga.Data;
using API_Manga.Models;
using API_Manga.Models.Services;
using API_Manga.Models.Utilities.Requests;
using API_Manga.Models.Utilities.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_Manga.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly IForumService _forumService;
        private readonly AppDbContext _context;
        public MangaController(IForumService forumservice, AppDbContext context)
        {
            _context = context;
            _forumService = forumservice;
        }

        #region Manga Methods
        [HttpGet("manga")]

        public Task<IEnumerable<Manga>> GetAllMangas()
        {
            return _forumService.GetAllMangas();

        }
        [HttpGet("manga/{id}")]

        public Task<GetMangaByIdResponse> GetMangaById(int id)
        {
            return _forumService.GetMangaById(id);

        }
        [HttpGet("manga/{name}")]

        public Task<GetMangaByNameResponse> GetMangaByName(string name)
        {
            return _forumService.GetMangaByName(name);
        }
        #endregion

        #region Forum Methods

        #region GET Methods
        public Task<PostResponse> GetPostByName(string name)
        {
            return _forumService.GetPostByName(name);
        }

        public Task<TopicResponse> GetTopicByName(string name)
        {
            return _forumService.GetTopicByName(name);
        }

        [HttpGet("usernumposts/{id}")]

        public Task<PostResponse> GetNumPostsOfUser(int id)
        {
            return _forumService.GetNumPostsOfUser(id);
        }
        [HttpGet("topicnumposts/{id}")]

        public Task<PostResponse> GetNumPostsOfTopic(int id)
        {
            return _forumService.GetNumPostsOfTopic(id);
        }
        [HttpGet("usernumreplies/{id}")]

        public Task<ReplyResponse> GetNumRepliesOfUser(int id)
        {
            return _forumService.GetNumRepliesOfUser(id);
        }
        [HttpGet("postnumreplies/{id}")]

        public Task<ReplyResponse> GetNumRepliesOfPost(int id)
        {
            return _forumService.GetNumRepliesOfPost(id);
        }
        #endregion

        #region POST Methods
        //POST api/<Manga>
        [HttpPost("CreatePost")]
        public Task<PostResponse> CreatePost([FromBody] CreatePostRequest post)
        {
            return _forumService.CreatePost(post);
        }
        [HttpPost("CreateReply")]

        public Task<ReplyResponse> CreateReply([FromBody] CreateReplyRequest post)
        {
            return _forumService.CreateReply(post);
        }
        [HttpPost("CreateTopic")]

        public Task<TopicResponse> CreateTopic([FromBody] CreateTopicRequest post)
        {
            return _forumService.CreateTopic(post);

        }
        #endregion

        #endregion

    }
}
