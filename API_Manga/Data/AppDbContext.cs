using API_Manga.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Manga.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
           
        }
        public DbSet<ForumPost> Posts { get; set; }
        public DbSet<ForumTopic> Topics { get; set; }
        public DbSet<ForumReply> Replies { get; set; }
        public DbSet<ForumUser> Users { get; set; }
        public DbSet<Manga> Mangas { get; set; }

    }
}
