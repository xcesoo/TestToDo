using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestToDo.Entities;

namespace TestToDo.Infrastructure.Persistence.Configurations;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");

        builder.HasIndex(r => r.Token)
            .IsUnique();
            
        builder.Property(r => r.Token)
            .HasMaxLength(500)
            .IsRequired()
            .HasColumnName("token");

        builder.Property(r => r.ExpiryDate)
            .IsRequired()
            .HasColumnName("expiry_date");

        builder.Property(r => r.IsRevoked)
            .IsRequired()
            .HasDefaultValue(false)
            .HasColumnName("is_revoked");

        builder.Property(r => r.CreatedDate)
            .IsRequired()
            .HasColumnName("created_date");

        builder.Property(r => r.UserId)
            .IsRequired()
            .HasColumnName("user_id");
    }
}