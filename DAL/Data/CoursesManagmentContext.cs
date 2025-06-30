using Microsoft.EntityFrameworkCore;
using DAL.Entities;

namespace DAL.Data
{
    public class CoursesManagmentContext : DbContext
    {
        public CoursesManagmentContext()
        {

        }
        public CoursesManagmentContext(DbContextOptions<CoursesManagmentContext> options) : base(options) { }
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Assignment> Assignment { get; set; } = null!;
        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Submission> Submissions { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;


    }
}
