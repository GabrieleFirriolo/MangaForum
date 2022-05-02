using API_Manga.Data;
using API_Manga.Models.Utilities.Requests;
using API_Manga.Models.Utilities.Responses;
using Microsoft.EntityFrameworkCore;
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

        public async Task<CreatePostResponse> CreatePost(CreatePostRequest request)
        {
            var Post = new ForumPost(request.Creator, request.Topic, new List<ForumReply> { new ForumReply (request.Creator,request.Message,DateTime.Now) });
            try
            {
                await _context.AddAsync(Post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new CreatePostResponse()
                {
                    state = false,
                    post = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new CreatePostResponse()
            {
                state = false,
                post  = Post,
                Error = null
            };
        }

        public async Task<CreateReplyResponse> CreateReply(CreateReplyRequest post)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateTopicResponse> CreateTopic(CreateTopicRequest post)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manga>> GetAllMangas()
        {
            return await _context.Mangas.ToListAsync();
        }

        public async Task<GetMangaByIdResponse> GetMangaById(int id)
        {
            var Manga = await _context.Mangas.FirstOrDefaultAsync(manga => manga.id_Manga == id);
            if (Manga == null)
            {
                return new GetMangaByIdResponse()
                {
                    state = false,
                    manga = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new GetMangaByIdResponse()
            {
                state = true,
                manga = Manga,
                Error = null,

            };

        }

        public async Task<GetMangaByNameResponse> GetMangaByName(string name)
        {
            var Manga = await _context.Mangas.Where(manga => manga.Title.ToLower().Contains(name.ToLower().Trim())).ToListAsync();
            if (Manga.Count() == 0)
            {
                return new GetMangaByNameResponse()
                {
                    state = false,
                    mangas = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new GetMangaByNameResponse()
            {
                state = true,
                mangas = Manga,
                Error = null,

            };
        }

        public async Task<PostResponse> GetPostsOfTopic(int id)
        {
            var listu = _context.Users.ToListAsync();
            var listt = _context.Topics.ToListAsync();
            var listm = _context.Mangas.ToListAsync();
            var listr = _context.Replies.ToListAsync();
            var Posts = await _context.Posts.Where(post => post.Topic.id_Topic == id).ToListAsync();
            if (Posts.Count() == 0)
            {
                return new PostResponse()
                {
                    state = false,
                    posts = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new PostResponse()
            {
                state = true,
                posts = Posts,
                Error = null,

            };
        }

        public async Task<PostResponse> GetPostsOfUser(int id)
        {
            //TEMP
            //var listu = _context.Users.ToListAsync();
            //var listt = _context.Topics.ToListAsync();
            //var listm = _context.Mangas.ToListAsync();
            //var listr = _context.Replies.ToListAsync();
            //var Posts = await _context.Posts.Where(x => x.Creator.id_User == id).ToListAsync();

            var Posts = await _context.Users.Where(x => x.id_User == id).Join(_context.Posts, u => u.id_User, p => p.Creator.id_User, (u, p) => p).ToListAsync();
             //.Join(_context.Topics, p => p.Topic, t => t.id_Topic).ToListAsync();

            if (Posts.Count() == 0)
            {
                return new PostResponse()
                {
                    state = false,
                    posts = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new PostResponse()
            {
                state = true,
                posts = Posts,
                Error = null,

            };
        }
    
        public async Task<ReplyResponse> GetRepliesOfUser(int id)
        {
            var listp = _context.Posts.ToListAsync();
            var listu = _context.Users.ToListAsync();
            var listt = _context.Topics.ToListAsync();
            var Replies = await _context.Replies.Where(reply => reply.Creator.id_User == id).ToListAsync();
            if (Replies.Count() == 0)
            {
                return new ReplyResponse()
                {
                    state = false,
                    replies = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new ReplyResponse()
            {
                state = true,
                replies = Replies,
                Error = null,

            };
        }

        public async Task<PostResponse> GetPostById(int id)
        {
            var listu = _context.Users.ToListAsync();
            var listt = _context.Topics.ToListAsync();
            var listm = _context.Mangas.ToListAsync();
            var listr = _context.Replies.ToListAsync();
            var Posts = await _context.Posts.Where(post => post.id_Post == id).ToListAsync();
            if (Posts.Count() == 0)
            {
                return new PostResponse()
                {
                    state = false,
                    posts = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new PostResponse()
            {
                state = true,
                posts = Posts,
                Error = null,

            };
        }

        public async  Task<TopicResponse> GetTopicByName(string name)
        {
            var listp = _context.Posts.ToListAsync();
            var listm = _context.Mangas.ToListAsync();
            var listr = _context.Replies.ToListAsync();
            var Topics = await _context.Topics.Where(topic => topic.Name.ToLower().Contains(name.ToLower().Trim())).ToListAsync();
            if (Topics.Count() == 0)
            {
                return new TopicResponse()
                {
                    state = false,
                    topics = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new TopicResponse()
            {
                state = true,
                topics = Topics,
                Error = null,

            };
        }
    }
}
