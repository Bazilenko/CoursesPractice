using System.Threading.Tasks;
using CoursesWeb.Repositories.Contracts;

namespace CoursesWeb.UOW.Contract
{
    public interface IUnitOfWork
    {
        IAssignmentRepository Assignments { get; }
        IAttendanceRepository Attendances { get; }
        ICourseRepository Courses { get; }
        IEnrollmentRepository Enrollments { get; }
        ILessonRepository Lessons { get; }
        IStudentRepository Students { get; }
        ISubmissionRepository Submissions { get; }
        ITeacherRepository Teachers { get; }

        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
        Task<int> CompleteAsync(CancellationToken cancellationToken);
        void Dispose();
    }
}
