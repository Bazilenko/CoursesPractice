using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class CoursesManagmentDbContextFactory : ICoursesManagmentDbContextFactory
    {
        private readonly string connectionString;
        public CoursesManagmentDbContextFactory(string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=CoursesDb;Trusted_Connection=True;TrustServerCertificate=True;")
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
