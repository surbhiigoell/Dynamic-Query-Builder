using Microsoft.EntityFrameworkCore;


namespace QueryBuilder.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
