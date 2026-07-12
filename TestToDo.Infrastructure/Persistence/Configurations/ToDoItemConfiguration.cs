using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestToDo.Entities;

namespace TestToDo.Infrastructure.Persistence.Configurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.ToTable("todo_items");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        
        builder.Property(c => c.Title)
            .HasMaxLength(100)
            .IsRequired()
            .HasColumnName("title");
        builder.HasIndex(c => c.Title)
            .HasMethod("gin")
            .HasOperators("gin_trgm_ops");
        
        builder.Property(c => c.Description)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasDefaultValue(null)
            .HasColumnName("description");
        builder.HasIndex(c => c.Description)
            .HasMethod("gin")
            .HasOperators("gin_trgm_ops");
        
        builder.Property(c => c.CategoryId)
            .IsRequired(false)
            .HasColumnName("category_id");
        
        builder.HasOne(c => c.Category)
            .WithMany()
            .IsRequired(false)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.Property(c => c.UserId)
            .IsRequired()
            .HasColumnName("user_id");
        
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(c => new { c.UserId, c.CategoryId });

        builder.Property(c => c.CreatedAt)
            .IsRequired()
            .HasColumnName("created_at");
        
        builder.Property(c=>c.Deadline)
            .IsRequired(false)
            .HasDefaultValue(null)
            .HasColumnName("deadline");
        
        builder.Property(c=>c.Priority)
            .HasConversion<string>()
            .HasColumnName("priority");
        
        builder.Property(c => c.IsCompleted)
            .HasDefaultValue(false)
            .HasColumnName("is_completed");
        
        builder.Property(c => c.CompletedAt)
            .IsRequired(false)
            .HasColumnName("completed_at");
    }
}