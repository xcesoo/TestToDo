using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestToDo.Entities;

namespace TestToDo.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.HasIndex(c => c.Email)
            .IsUnique();
        builder.Property(c => c.Email)
            .HasMaxLength(256)
            .IsRequired()
            .HasColumnName("email");
        
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("name");

        builder.Property(c => c.PasswordHash)
            .IsRequired()
            .HasColumnName("password_hash");;

        builder.Property(c => c.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.HasMany(u => u.RefreshTokens)
            .WithOne(r => r.User)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Navigation(u => u.RefreshTokens)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .AutoInclude();
    }
}