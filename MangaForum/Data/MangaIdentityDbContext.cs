using MangaForum.Areas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MangaForum.Data
{
    public class MangaIdentityDbContext : IdentityDbContext<ForumUser>
    {
        public MangaIdentityDbContext(DbContextOptions<MangaIdentityDbContext> options)
            : base(options)
        {
        }
    }
}
