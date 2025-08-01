﻿using DAL.Entities;

namespace CoursesWeb.Repositories.Contracts
{
    public interface IAttendanceRepository : IGenericRepository<AttendanceEntity>
    {
        Task<IEnumerable<AttendanceEntity>> GetAttendanceWithStudentsByStudentIdAsync(int id);
    }
}
