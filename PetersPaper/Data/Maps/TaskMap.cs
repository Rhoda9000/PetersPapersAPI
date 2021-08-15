using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetersPaper.Data.Models;

namespace PetersPaper.Data.Maps
{
    internal sealed class TaskMap : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.ToTable("Tasks", "dbo");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.UserId).IsRequired();
            builder.Property(i => i.TaskStatusId).IsRequired();
            builder.Property(i => i.Title).IsRequired();
            builder.Property(i => i.Description).IsRequired();
            builder.Property(i => i.DueDate).IsRequired();
            builder.Property(i => i.DateCreated).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired();
            builder.HasOne(i => i.TaskStatus).WithOne(i => i.Task).HasForeignKey<Task>(i => i.TaskStatusId);
        }
    }
}
