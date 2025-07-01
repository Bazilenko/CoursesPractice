using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DAL.Data.Config
{
    public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
    {
        public void Configure(EntityTypeBuilder<LessonEntity> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Tittle).IsRequired().HasMaxLength(100);
            builder.Property(l => l.VideoTitle).HasMaxLength(100);
            builder.Property(l => l.AudioTitle).HasMaxLength(100);

            builder.HasOne(l => l.Course)
                .WithMany(c => c.Lessons)
                .HasForeignKey(l => l.CourseId);

            builder.HasOne(l => l.Teacher)
                .WithMany(t => t.Lessons)
                .HasForeignKey(t => t.TeacherId);

            builder.HasMany(l => l.Assignments)
                .WithOne(a => a.Lesson)
                .HasForeignKey(a => a.LessonId);

            builder.HasMany(l => l.Attendances)
                .WithOne(a => a.Lesson)
                .HasForeignKey(a => a.LessonId);
        }
    }
}
