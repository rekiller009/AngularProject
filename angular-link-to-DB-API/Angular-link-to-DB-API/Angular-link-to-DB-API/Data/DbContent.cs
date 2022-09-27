using Angular_link_to_DB_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Angular_link_to_DB_API.Data
{
    public class DbContent: DbContext
    {
        public DbContent(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
