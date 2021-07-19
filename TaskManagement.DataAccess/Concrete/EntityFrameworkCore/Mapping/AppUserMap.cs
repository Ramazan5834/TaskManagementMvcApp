using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManagement.Entities.Concrete;

namespace TaskManagement.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.Name).HasMaxLength(100);
            builder.Property(I => I.Surname).HasMaxLength(100);
            builder.HasMany(I => I.Gorevler)
                .WithOne(I => I.AppUser)
                .HasForeignKey(I => I.AppUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
