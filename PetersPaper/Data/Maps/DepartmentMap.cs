using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetersPaper.Data.Models;


namespace PetersPaper.Data.Maps
{
    internal sealed class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "dbo");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired();
            builder.Property(i => i.Name).IsRequired();
            builder.Property(i => i.IsDeleted).IsRequired();
        }
    }
}
