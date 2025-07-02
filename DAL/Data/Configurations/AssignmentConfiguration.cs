using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Config
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<AssignmentEntity>
    {
        public void Configure(EntityTypeBuilder<AssignmentEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tittle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.DueDate).IsRequired();

            builder.
                HasOne(x => x.Lesson)
                .WithMany(x => x.Assignments)
                .HasForeignKey(x => x.LessonId);
        }
    }
}
