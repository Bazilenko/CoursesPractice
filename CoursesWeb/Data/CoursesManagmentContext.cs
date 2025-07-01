using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Data
{
    public class CoursesManagmentContext : DbContext
    {
        public CoursesManagmentContext()
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
        public CoursesManagmentContext(DbContextOptions<CoursesManagmentContext> options) : base(options) { }
        public virtual DbSet<AssignmentEntity> Assignment { get; set; } = null!;
        public virtual DbSet<AttendanceEntity> Attendances { get; set; } = null!;
        public virtual DbSet<CourseEntity> Courses { get; set; } = null!;
        public virtual DbSet<EnrollmentEntity> Enrollments { get; set; } = null!;
        public virtual DbSet<LessonEntity> Lessons { get; set; } = null!;
        public virtual DbSet<StudentEntity> Students { get; set; } = null!;
        public virtual DbSet<SubmissionEntity> Submissions { get; set; } = null!;
        public virtual DbSet<TeacherEntity> Teachers { get; set; } = null!;


    }
}
