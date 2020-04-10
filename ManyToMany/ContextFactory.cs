using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ManyToMany
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        private const string ConnectionStringLocal = "Server=localhost\\SQLEXPRESS;Database=many-to-many;Trusted_Connection=True;";

        public Context CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseSqlServer(ConnectionStringLocal);
            return new Context(builder.Options);
        }
    }
}
