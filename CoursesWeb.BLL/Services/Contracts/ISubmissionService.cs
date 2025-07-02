using CoursesWeb.DTOs.Request.Submission;
using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface ISubmissionService
    {
        Task<IEnumerable<SubmissionMiniResposeDTO>> GetAllAsync();
        Task<SubmissionMiniResposeDTO> GetByIdAsync(int id);
        Task<SubmissionMiniResposeDTO> CreateAsync(SubmissionCreateReqDTO dto, CancellationToken cancellationToken = default);
        Task<SubmissionMiniResposeDTO> UpdateAsync(int id, SubmissionUpdateReqDTO dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
