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
        
        builder.Property(c => c.Description)
            .HasMaxLength(500)
            .IsRequired(false)
            .HasDefaultValue(null)
            .HasColumnName("description");
        
        builder.Property(c => c.CategoryId)
            .IsRequired()
            .HasColumnName("category_id");
        
        builder.HasOne(c => c.Category)
            .WithMany()
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

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