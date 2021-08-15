using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetersPaper.Data.Models;

namespace PetersPaper.Data.Maps
{
    internal sealed class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "dbo");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.DepartmentId).IsRequired();
            builder.Property(i => i.FirstName).IsRequired();
            builder.Property(i => i.LastName).IsRequired();
            builder.Property(i => i.Email).IsRequired();
            builder.Property(i => i.CellNumber).IsRequired();
            builder.Property(i => i.DateCreated).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired();
            builder.HasOne(i => i.Department).WithOne(i => i.User).HasForeignKey<User>(i => i.DepartmentId);
            builder.HasMany(i => i.Tasks);
        }
    }
}
