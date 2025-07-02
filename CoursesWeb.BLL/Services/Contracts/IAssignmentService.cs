using CoursesWeb.DTOs.Request.Assignment;
using CoursesWeb.DTOs.Request.Course;
using CoursesWeb.DTOs.Response;

namespace CoursesWeb.Services.Contracts
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentFullResponseDTO>> GetAllAsync();
        Task<AssignmentFullResponseDTO> GetByIdAsync(int id);
        Task<AssignmentFullResponseDTO> CreateAsync(CreateAssignmentReqDTO dto, CancellationToken cancellationToken = default);
        Task<AssignmentFullResponseDTO> UpdateAsync(int id, CreateAssignmentReqDTO dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
