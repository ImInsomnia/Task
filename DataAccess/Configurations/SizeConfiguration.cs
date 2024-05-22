using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Concrete;

namespace DataAccess.Configurations
{
    internal class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes");
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(true);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique()
                .HasDatabaseName("uk_Size_Name_Deleted");
        }
    }
}
