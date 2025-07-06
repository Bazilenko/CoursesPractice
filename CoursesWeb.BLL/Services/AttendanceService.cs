using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoursesWeb.BLL.DTOs.Response;
using CoursesWeb.DTOs.Request.Attendance;
using CoursesWeb.DTOs.Response;
using CoursesWeb.Exceptions;
using CoursesWeb.Services.Contracts;
using CoursesWeb.UOW.Contract;
using Mapster;

namespace CoursesWeb.BLL.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AttendanceService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AttendanceWithStudentResponseDTO>> GetByStudentIdAsync(int studentId)
        {
            var attendances = await _unitOfWork.Attendances.GetAttendanceWithStudentsByStudentIdAsync(studentId);
            if (attendances == null)
                throw new NotFoundException($"Student with {studentId} not found!");
            var dto = attendances.Adapt<List<AttendanceWithStudentResponseDTO>>();
            return dto; ;

        }

        
    }
}
