using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Data.Config
{
    public class SubmissionConfiguration : IEntityTypeConfiguration<SubmissionEntity>
    {
        public void Configure(EntityTypeBuilder<SubmissionEntity> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Grade).IsRequired().HasMaxLength(30);

            builder.HasOne(s => s.Assignment)
                .WithMany(a => a.Submissions)
                .HasForeignKey(a => a.AssignmentId);

            builder.HasOne(s => s.Student)
                .WithMany(s => s.Submissions)
                .HasForeignKey(s => s.StudentId);
        }
    }
}
