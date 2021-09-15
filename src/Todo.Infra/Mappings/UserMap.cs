using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Models.Users;

namespace Todo.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(c => c.Id);
            builder.OwnsOne(c => c.Name).Property(l => l.FirstName).HasMaxLength(60).HasColumnName("FirstName");
            builder.OwnsOne(c => c.Name).Property(l => l.LastName).HasMaxLength(60).HasColumnName("LastName");
            builder.OwnsOne(c => c.Login).Property(l => l.UserName).HasMaxLength(20).HasColumnName("UserName");
            builder.OwnsOne(c => c.Login).Property(l => l.Password).HasMaxLength(10).IsFixedLength().HasColumnName("Password");
            builder.OwnsOne(c => c.Login).Ignore(l => l.ConfirmPassword);
            builder.OwnsOne(c => c.Email).Property(e => e.Address).HasMaxLength(160).HasColumnName("Email");
        }
    }
}
