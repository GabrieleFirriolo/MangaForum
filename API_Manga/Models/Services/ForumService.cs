using API_Manga.Data;
using API_Manga.Models.Utilities.Requests;
using API_Manga.Models.Utilities.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Models.Services
{
    public class ForumService : IForumService
    {
        private readonly AppDbContext _context;
        public ForumService(AppDbContext context)
        {
            _context = context;
        }
        public Task<CreatePostResponse> CreatePost(CreatePostRequest post)
        {
            throw new NotImplementedException();
        }

        public Task<CreateReplyResponse> CreateReply(CreateReplyRequest post)
        {
            throw new NotImplementedException();
        }

        public Task<CreateTopicResponse> CreateTopic(CreateTopicRequest post)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manga>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<GetMangaByIdResponse> GetMangaById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetMangaByNameResponse> GetMangaByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
