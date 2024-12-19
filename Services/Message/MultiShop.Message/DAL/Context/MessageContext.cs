using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Entites;

namespace MultiShop.Message.DAL.Context
{
    public class MessageContext :DbContext
    {
        public MessageContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
