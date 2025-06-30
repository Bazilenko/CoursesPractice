using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DAL.Data.Config
{
    public class TeacherConfiguration : IEntityTypeConfiguration<TeacherEntity>
    {
        public void Configure(EntityTypeBuilder<TeacherEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Bio).IsRequired().HasMaxLength(500);
            builder.Property(x => x.MiddleName).IsRequired(false).HasMaxLength(100);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Experience).IsRequired(false);
            builder.Property(x => x.PhotoUrl).IsRequired();
            builder.Property(x => x.Nationality).IsRequired().HasMaxLength(100);

            builder.HasMany(x => x.Lessons)
                .WithOne(x => x.Teacher)
                .HasForeignKey(x => x.TeacherId);
        }
    }
}
