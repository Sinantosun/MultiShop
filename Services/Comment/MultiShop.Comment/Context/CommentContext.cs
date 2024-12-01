using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entites;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<UserComment> UserComments { get; set; }
    }
}
