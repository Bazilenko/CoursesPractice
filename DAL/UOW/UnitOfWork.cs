using CoursesWeb.Repositories.Contracts;
using CoursesWeb.UOW.Contract;
using DAL.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace CoursesWeb.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoursesManagmentContext _context;
        private IDbContextTransaction _transaction;
        public IAssignmentRepository Assignments { get; }

        public IAttendanceRepository Attendances { get; }

        public ICourseRepository Courses { get; }

        public IEnrollmentRepository Enrollments { get; }

        public ILessonRepository Lessons { get; }

        public IStudentRepository Students { get; }

        public ISubmissionRepository Submissions { get; }

        public ITeacherRepository Teachers { get; }

        public UnitOfWork(CoursesManagmentContext context,
            IAssignmentRepository assignments,
            IAttendanceRepository attendances,
            ICourseRepository courses,
            IEnrollmentRepository enrollments,
            ILessonRepository lessons,
            IStudentRepository students,
            ISubmissionRepository submissions,
            ITeacherRepository teachers)
        {
            this._context = context;
            this.Assignments = assignments;
            this.Attendances = attendances;
            this.Courses = courses;
            this.Enrollments = enrollments;
            this.Lessons = lessons;
            this.Students = students;
            this.Submissions = submissions;
            this.Teachers = teachers;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("The transaction has not been started. [CommitTransactionAsync()]");
            }
            await _transaction.CommitAsync(cancellationToken);
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("The transaction has not been started. [RollbackTransactionAsync()]");
            }
            await _transaction.RollbackAsync(cancellationToken);
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();

            _context?.Dispose();
        }
    }
}
