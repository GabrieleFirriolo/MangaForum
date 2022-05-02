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
        public MangaController(IForumService forumservice)
        {
            _forumService = forumservice;
        }

        #region Manga Methods
        [HttpGet("getallmanga")]

        public Task<IEnumerable<Manga>> GetAllMangas()
        {
            return _forumService.GetAllMangas();

        }
        [HttpGet("manga/byid={id}")]

        public Task<GetMangaByIdResponse> GetMangaById(int id)
        {
            return _forumService.GetMangaById(id);

        }
        [HttpGet("manga/byname={name}")]

        public Task<GetMangaByNameResponse> GetMangaByName(string name)
        {
            return _forumService.GetMangaByName(name);
        }
        #endregion

        #region Forum Methods

        #region GET Methods

        [HttpGet("topic/byname={name}")]

        public Task<TopicResponse> GetTopicByName(string name)
        {
            return _forumService.GetTopicByName(name);
        }

        [HttpGet("userposts/byid={id}")]

        public Task<PostResponse> GetPostsOfUser(int id)
        {
            return _forumService.GetPostsOfUser(id);
        }
        [HttpGet("topicposts/byid={id}")]

        public Task<PostResponse> GetPostsOfTopic(int id)
        {
            return _forumService.GetPostsOfTopic(id);
        }
        [HttpGet("userreplies/byid={id}")]

        public Task<ReplyResponse> GetRepliesOfUser(int id)
        {
            return _forumService.GetRepliesOfUser(id);
        }
        #endregion

        #region POST Methods
        //POST api/<Manga>
        [HttpPost("CreatePost")]
        public Task<CreatePostResponse> CreatePost([FromBody] CreatePostRequest post)
        {
            return _forumService.CreatePost(post);
        }
        [HttpPost("CreateReply")]

        public Task<CreateReplyResponse> CreateReply([FromBody] CreateReplyRequest post)
        {
            return _forumService.CreateReply(post);
        }
        [HttpPost("CreateTopic")]

        public Task<CreateTopicResponse> CreateTopic([FromBody] CreateTopicRequest post)
        {
            return _forumService.CreateTopic(post);

        }
        #endregion

        #endregion

    }
}
