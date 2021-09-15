using Microsoft.EntityFrameworkCore;
using Todo.Common.Notifications;
using Todo.Domain.Models.Users;
using Todo.Domain.ValueObjects.EmailObj;
using Todo.Domain.ValueObjects.LoginObj;
using Todo.Domain.ValueObjects.NameObj;
using Todo.Infra.Mappings;

namespace Todo.Infra.Contexts
{
    public class TodoDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //optionsBuilder.UseSqlServer(Runtime.ConnectionStringSqlServer);

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseInMemoryDatabase("Database");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Notification>();
            builder.Ignore<Name>();
            builder.Ignore<Login>();
            builder.Ignore<Email>();

            builder.ApplyConfiguration(new UserMap());
        }
    }
}
