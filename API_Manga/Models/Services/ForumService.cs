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
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();

            ForumPost Post = new ForumPost();
            try
            {
                 Post = new ForumPost(_context.Users.Where(x => x.id_User == request.id_Creator).FirstOrDefault(),
              _context.Posts.Where(x => x.Topic.id_Topic == request.id_Topic).FirstOrDefault().Topic,
              new List<ForumReply> {
                    new ForumReply
                    (
                        _context.Posts.Where(x => x.Creator.id_User == request.id_Creator).FirstOrDefault().Creator,
                        request.Message,
                        DateTime.Now.Date
                        )

              });;
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

        public async Task<CreateReplyResponse> CreateReply(CreateReplyRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();

            ForumReply Reply = new ForumReply();
            try
            {
                Reply = new ForumReply
                    (
                    _context.Users.Where(x => x.id_User == request.id_Creator).FirstOrDefault(), 
                    request.Reply,
                    DateTime.Now.Date, 
                    _context.Posts.Where(x => x.id_Post == request.id_Post).FirstOrDefault()
                    ); 
                await _context.AddAsync(Reply);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new CreateReplyResponse()
                {
                    state = false,
                    reply = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new CreateReplyResponse()
            {
                state = false,
                reply = Reply,
                Error = null
            };
        }

        public async Task<CreateTopicResponse> CreateTopic(CreateTopicRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();

            ForumTopic Topic = new ForumTopic();
            try
            {
                Topic = new ForumTopic
                {
                    Name = request.Name,
                    Manga = await _context.Mangas.Where(x => x.id_Manga == request.id_Manga).FirstOrDefaultAsync()
                };
                   

                    
                await _context.AddAsync(Topic);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new CreateTopicResponse()
                {
                    state = false,
                    topic = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new CreateTopicResponse()
            {
                state = false,
                topic = Topic,
                Error = null
            };
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
            var Posts = await _context.Posts.Where(post => post.Topic.id_Topic == id).ToListAsync();
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
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
            var Posts = await _context.Posts.Where(x => x.Creator.id_User == id).ToListAsync();
            await (from p in _context.Posts select new
                          {
                             p.Creator,
                             p.Topic,
                             p.Topic.Manga,
                             p.Replies
                          }).ToListAsync();
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
            var Replies = await _context.Replies.Where(reply => reply.Creator.id_User == id).ToListAsync();
            await (from p in _context.Posts
                   select new
                   {
                       p.id_Post,
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
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
            var Posts = await _context.Posts.Where(post => post.id_Post == id).ToListAsync();
            await (from p in _context.Posts
                   select new
                   {
                       p.id_Post,
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
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
            var Topics = await _context.Topics.Where(topic => topic.Name.ToLower().Contains(name.ToLower().Trim())).ToListAsync();
            await (from p in _context.Topics
                   select new
                   {
                     p.id_Topic,
                     p.Name,
                     p.Manga
                   }).ToListAsync();
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

        public Task<DeleteReplyResponse> DeleteReply(DeleteReplyRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeleteTopicResponse> DeleteTopic(DeleteTopicRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<DeletePostResponse> DeletePost(DeletePostRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
