using API_Manga.Models.Utilities.Requests;
using API_Manga.Models.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Services
{
    public interface IForumService
    {
        public Task<IEnumerable<Manga>> GetAllMangas();
        public Task<GetMangaByNameResponse> GetMangaByName(string name);
        public Task<GetMangaByIdResponse> GetMangaById(int id);
        public Task<PostResponse> GetPostById(int id);
        public Task<TopicResponse> GetTopicByName (string name);


        public Task<PostResponse> GetPostsOfUser(int id);
        public Task<PostResponse> GetPostsOfTopic(int id);
        public Task<ReplyResponse> GetRepliesOfUser(int id);


        public Task<CreatePostResponse> CreatePost(CreatePostRequest post);
        public Task<CreateTopicResponse> CreateTopic(CreateTopicRequest post);
        public Task<CreateReplyResponse> CreateReply(CreateReplyRequest post);

    }
}
