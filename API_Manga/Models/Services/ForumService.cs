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

        public async Task<IEnumerable<ForumTopic>> GetAllTopics()
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
                   }).ToListAsync();
            return await _context.Topics.ToListAsync();
        }
        public async Task<IEnumerable<ForumPost>> GetAllPosts()
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
                   }).ToListAsync();
            return await _context.Posts.ToListAsync();
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
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
                   }).ToListAsync();
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
        public async Task<ReplyResponse> GetRepliesOfTopic(int id)
        {
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
                   }).ToListAsync();
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator.id_User,
                       p.Creator.Nome,
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
            var Posts = await _context.Posts.Where(post => post.Topic.id_Topic == id).ToListAsync();
            List<ForumReply> Replies = new List<ForumReply>();
            foreach (var post in Posts)
            {
                if (post.Replies != null)
                    Replies.AddRange(post.Replies);
            }
            var count = Replies.Count();
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
        public async Task<PostResponse> GetPostsOfUser(int id)
        {
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
                   }).ToListAsync();
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
            await (from p in _context.Replies
                   select new
                   {
                       p.Post,
                       p.Reply,
                       p.Creator
                   }).ToListAsync();
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
        public async Task<CreateUserResponse> GetUserByEmail(string email)
        {
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
                   }).ToListAsync();
            email = email.Replace("%40", "@");
            ForumUser User = await _context.Users.Where(user => user.Email.ToLower().Trim() == email.ToLower().Trim()).FirstOrDefaultAsync();
      
            if (User == null)
            {
                return new CreateUserResponse()
                {
                    state = false,
                    user = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new CreateUserResponse()
            {
                state = true,
                user = User,
                Error = null,

            };
        }
        public async Task<CreateUserResponse> GetUserById(int id)
        {
            ForumUser User = await _context.Users.Where(user => user.id_User == id).FirstOrDefaultAsync();

            if (User == null)
            {
                return new CreateUserResponse()
                {
                    state = false,
                    user = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new CreateUserResponse()
            {
                state = true,
                user = User,
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
                       p.Replies,
                   }).ToListAsync();
            await (from p in _context.Replies
                   select new
                   {
                     p.Creator
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
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator
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
        public async Task<CreateReplyResponse> GetReplyById(int id)
        {
            await (from p in _context.Replies
                   select new
                   {
                       p.id_Reply,
                       p.Creator,
                       p.ReplyDate,
                       p.Post,
                       p.Post.Topic,
                       p.Post.Replies,
                       p.Reply
                   }).ToListAsync();
            var reply = await _context.Replies.Where(reply => reply.id_Reply == id).FirstOrDefaultAsync();
           
            if (reply == null)
            {
                return new CreateReplyResponse()
                {
                    state = false,
                    reply = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new CreateReplyResponse()
            {
                state = true,
                reply = reply,
                Error = null,

            };
        }
        public async Task<CreateTopicResponse> GetTopicById(int id)
        {

            var Topics = await _context.Topics.Where(topic => topic.id_Topic == id).FirstOrDefaultAsync();
            await (from p in _context.Topics
                   select new
                   {
                       p.id_Topic,
                       p.Name,
                       p.Manga
                   }).ToListAsync();
            if (Topics == null)
            {
                return new CreateTopicResponse()
                {
                    state = false,
                    topic = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new CreateTopicResponse()
            {
                state = true,
                topic = Topics,
                Error = null,

            };
        }
        public async Task<CreatePostResponse> GetPostByReplyId(int id)
        {
            await (from p in _context.Replies
                   select new
                   {
                       p.Creator,
                       p.ReplyDate,
                       p.Post,
                       p.Post.Replies,
                       p.Reply,
                       p.Post.Topic,
                       p.Post.Topic.Manga
                   }).ToListAsync();
        
            var reply = await _context.Replies.Where(x => x.id_Reply == id).FirstOrDefaultAsync();

            if (reply.Post == null)
            {
                return new CreatePostResponse()
                {
                    state = false,
                    post = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            return new CreatePostResponse()
            {
                state = true,
                post = reply.Post,
                Error = null,

            };
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
                var creator = _context.Users.Where(x => x.id_User == request.id_Creator).FirstOrDefault();
                var topic = _context.Topics.Where(x => x.id_Topic == request.id_Topic).FirstOrDefault();
                Post = new ForumPost(creator,topic,
                new List<ForumReply> {
                    new ForumReply
                    (   creator,
                        request.Message,
                        DateTime.Now
                        )});
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
                state = true,
                post = Post,
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
                    DateTime.Now,
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
                state = true,
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
                state = true,
                topic = Topic,
                Error = null
            };
        }
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();

            ForumUser User = new ForumUser();
            try
            {
                User = new ForumUser
                {
                    Nome = request.Nome,
                    Cognome = request.Cognome,
                    DataDiNascita = request.DataDiNascita,
                    Nazione = request.Nazione,
                    Email = request.Email,
                    UserImage = request.UserImage
                };

                await _context.AddAsync(User);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new CreateUserResponse()
                {
                    state = false,
                    user = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new CreateUserResponse()
            {
                state = true,
                user = User,
                Error = null
            };
        }
        public async Task<CreateUserResponse> ModUser(ModUserRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();


            ForumUser User = await _context.Users.FirstOrDefaultAsync(user => user.id_User == request.id_User);
            if (User == null)
            {
                return new CreateUserResponse()
                {
                    state = true,
                    user = null,
                    Error = new List<string> { "Not Found" }
                };
            }
            try
            {
                User.Nome = request.Nome;
                User.Cognome = request.Cognome;
                User.DataDiNascita = request.DataDiNascita;
                User.Nazione = request.Nazione;
                User.UserImage = request.UserImage;
                    await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new CreateUserResponse()
                {
                    state = false,
                    user = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new CreateUserResponse()
            {
                state = true,
                user = User,
                Error = null
            };

        }
        public async Task<DeleteReplyResponse> DeleteReply(DeleteReplyRequest request)
        {
            await (from p in _context.Replies
                   select new
                   {
                       p.id_Reply,
                       p.Post,
                       p.Creator,
                       p.Post.id_Post,
                   }).ToListAsync();
            ForumReply reply = await _context.Replies.FirstOrDefaultAsync(reply => reply.id_Reply == request.id_Reply);
            if (reply == null)
            {
                return new DeleteReplyResponse()
                {
                    state = false,
                    deleted_reply = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            try
            {
                _context.Replies.Remove(reply);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new DeleteReplyResponse()
                {
                    state = false,
                    deleted_reply = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new DeleteReplyResponse()
            {
                state = true,
                deleted_reply = reply,
                Error = null
            };
        }
        public async Task<DeleteTopicResponse> DeleteTopic(DeleteTopicRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Topic.Name,
                       p.Topic.id_Topic,
                       p.Replies
                   }).ToListAsync();
            ForumTopic topic = await _context.Topics.FirstOrDefaultAsync(topic => topic.id_Topic == request.id_Topic);
            if (topic == null)
            {
                return new DeleteTopicResponse()
                {
                    state = false,
                    deleted_topic = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            try
            {
                foreach (ForumPost post in _context.Posts)
                {
                    if(post.Topic.id_Topic == topic.id_Topic)
                    {
                        _context.Posts.Remove(post);
                    }
                }
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new DeleteTopicResponse()
                {
                    state = false,
                    deleted_topic = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new DeleteTopicResponse()
            {
                state = true,
                deleted_topic = topic,
                Error = null
            };
        }
        public async Task<DeletePostResponse> DeletePost(DeletePostRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.id_Post,
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();
            ForumPost post = await _context.Posts.FirstOrDefaultAsync(post => post.id_Post == request.id_Post);
            if (post == null)
            {
                return new DeletePostResponse()
                {
                    state = false,
                    deleted_post = null,
                    Error = new List<string>() { "Not Found" }
                };
            }
            try
            {
                //ON CASCADE
                foreach (ForumReply reply in post.Replies)
                {
                    _context.Replies.Remove(reply);
                }
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return new DeletePostResponse()
                {
                    state = false,
                    deleted_post = null,
                    Error = new List<string> { ex.Message }
                };
            }
            return new DeletePostResponse()
            {
                state = true,
                deleted_post = post,
                Error = null
            };
        }
        public async Task<CreateTopicResponse> ModTopic(ModTopicRequest request)
        {
            await (from p in _context.Posts
                   select new
                   {
                       p.Creator,
                       p.Topic,
                       p.Topic.Manga,
                       p.Replies
                   }).ToListAsync();


            ForumTopic Topic = await _context.Topics.FirstOrDefaultAsync(topic => topic.id_Topic == request.id_Topic);
            if (Topic == null)
            {
                return new CreateTopicResponse()
                {
                    state = true,
                    topic = null,
                    Error = new List<string> { "Not Found"}
                };
            }
            try
            {
                Topic.Name = request.Name;
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
                state = true,
                topic = Topic,
                Error = null
            };

        }
        public async Task<CreateReplyResponse> ModReply(ModReplyRequest request)
        {

            await (from m in _context.Replies
                   select new
                   {
                       m.id_Reply,
                       m.ReplyDate,
                       m.Creator,
                       m.Reply,
                       m.Post
                   }).ToListAsync();

            ForumReply Reply = await _context.Replies.FirstOrDefaultAsync(reply => reply.id_Reply == request.id_Reply);
            if (Reply == null)
            {
                return new CreateReplyResponse()
                {
                    state = false,
                    reply = null,
                    Error = new List<string> { "Not Found" }
                };
            }
            try
            {
                Reply.Reply = request.Reply;
                Reply.ReplyDate = DateTime.Now;
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
                state = true,
                reply = Reply,
                Error = null
            };
        }


    }
}
