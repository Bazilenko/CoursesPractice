using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class CoursesManagmentDbContextFactory : ICoursesManagmentDbContextFactory
    {
        private readonly string connectionString;
        public CoursesManagmentDbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public CoursesManagmentContext CreateDbContext()
        {
            DbContextOptionsBuilder<CoursesManagmentContext> options = new();
            options.UseSqlServer(connectionString);

            return new CoursesManagmentContext(options.Options);
        }
    }
}
