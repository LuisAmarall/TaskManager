using TaskManager.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManager.Infrastructure.Persistence.Configuration;

public class TasksConfiguration : IEntityTypeConfiguration<Tasks>
{
    public void Configure(EntityTypeBuilder<Tasks> builder)
    {
        builder.ToTable("Tasks");

        builder.HasKey(k => k.Id);

        builder.Property(p =>p.Title).HasColumnName("Title").HasColumnType("VARCHAR").HasMaxLength(20).IsRequired();

        builder.Property(p => p.Description).HasColumnName("Description").HasColumnType("VARCHAR").HasMaxLength(200).IsRequired();

        builder.Property(p => p.Status).HasColumnName("Status").HasColumnType("INT").IsRequired();

        builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt").HasColumnType("DATETIME").IsRequired(false);

        builder.Property(p => p.InProcess).HasColumnName("InProcess").HasColumnType("DATETIME").IsRequired(false);

        builder.Property(p => p.CompletedAt).HasColumnName("CompletedAt").HasColumnType("DATETIME").IsRequired(false);

        builder.Property(p => p.DeletedAt).HasColumnName("DeletedAt").HasColumnType("DATETIME").IsRequired(false);
    }
}