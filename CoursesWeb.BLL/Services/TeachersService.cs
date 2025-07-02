using AutoMapper;
using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.DTOs.Response;
using CoursesWeb.Exceptions;
using CoursesWeb.Services.Contracts;
using CoursesWeb.UOW.Contract;
using DAL.Entities;

namespace CoursesWeb.Services
{
    public class TeachersService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TeachersService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<TeacherMiniResponseDTO> CreateAsync(TeacherCreateReqDTO dto, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeacherMiniResponseDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherMiniResponseDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TeacherEntity> UpdateAsync(int id, TeacherUpdateReqDTO dto, CancellationToken cancellationToken = default)
        {
            var teacherEntity = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacherEntity == null)
                throw new NotFoundException($"Teachers with {id} cant be found and updated in database!");
            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);
                await _unitOfWork.Teachers.UpdateAsync(_mapper.Map<TeacherEntity>(dto));
                await _unitOfWork.CompleteAsync(cancellationToken);

                await _unitOfWork.CommitTransactionAsync(cancellationToken);
                return await _unitOfWork.Teachers.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException("Error in transaction while updating information about driver", ex);
            }
        }

        Task<TeacherMiniResponseDTO> ITeacherService.UpdateAsync(int id, TeacherUpdateReqDTO dto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
