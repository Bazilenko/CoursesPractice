
using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.DTOs.Response;
using CoursesWeb.Exceptions;
using CoursesWeb.Repositories.Contracts;
using CoursesWeb.Services.Contracts;
using CoursesWeb.UOW.Contract;
using DAL.Entities;
using Mapster;
using MapsterMapper;

namespace CoursesWeb.Services
{
    public class TeachersService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
       
        

        public TeachersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;       
        }
        public async Task<TeacherCreateReqDTO> CreateAsync(TeacherCreateReqDTO dto, CancellationToken cancellationToken = default)
        {
            try
            {
                // DTO → Entity
                var teacherEntity = dto.Adapt<TeacherEntity>();

                await _unitOfWork.BeginTransactionAsync(cancellationToken);
                await _unitOfWork.Teachers.AddAsync(teacherEntity);
                await _unitOfWork.CompleteAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

                // Entity → DTO
                var responseDto = teacherEntity.Adapt<TeacherCreateReqDTO>();
                return responseDto;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException("Error while creating new teacher", ex);
            }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher == null)
                throw new NotFoundException($"Teacher with id {id} not found!");

            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);
                await _unitOfWork.Teachers.DeleteAsync(teacher);
                await _unitOfWork.CompleteAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException($"Error while deleting teacher with id {id}", ex);
            }
        }

        public async Task<IEnumerable<TeacherMiniResponseDTO>> GetAllAsync()
        {
            var teachers = await _unitOfWork.Teachers.GetAllAsync();
            var dtoList = teachers.Adapt<IEnumerable<TeacherMiniResponseDTO>>();
            return dtoList;
        }

        public async Task<TeacherCreateReqDTO> GetByIdAsync(int id)
        {
            var teacher = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacher == null)
                throw new NotFoundException($"Teacher with id {id} not found!");

            return teacher.Adapt<TeacherCreateReqDTO>();
            
        }

        public async Task<TeacherMiniResponseDTO> UpdateAsync(int id, TeacherUpdateReqDTO dto, CancellationToken cancellationToken = default)
        {
            var teacherEntity = await _unitOfWork.Teachers.GetByIdAsync(id);
            if (teacherEntity == null)
                throw new NotFoundException($"Teacher with id {id} not found in database!");

            try
            {
                await _unitOfWork.BeginTransactionAsync(cancellationToken);

                dto.Adapt(teacherEntity);

                await _unitOfWork.Teachers.UpdateAsync(teacherEntity);
                await _unitOfWork.CompleteAsync(cancellationToken);
                await _unitOfWork.CommitTransactionAsync(cancellationToken);

               
                return teacherEntity.Adapt<TeacherMiniResponseDTO>();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw new ApplicationException("Error in transaction while updating information about driver", ex);
            }
        }

     
    }
}
