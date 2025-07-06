using Mapster;
using CoursesWeb.DTOs.Request.Assignment;
using CoursesWeb.DTOs.Request.Attendance;
using CoursesWeb.DTOs.Request.Course;
using CoursesWeb.DTOs.Request.Enrollment;
using CoursesWeb.DTOs.Request.Lesson;
using CoursesWeb.DTOs.Request.Student;
using CoursesWeb.DTOs.Request.Submission;
using CoursesWeb.DTOs.Request.Teacher;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.DTOs.Response;
using DAL.Entities;
using CoursesWeb.BLL.DTOs.Response;

public class Mapping : IRegister
    {
        

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TeacherCreateReqDTO, TeacherEntity>();
        config.NewConfig<TeacherUpdateReqDTO, TeacherEntity>();
        config.NewConfig<TeacherEntity, TeacherMiniResponseDTO>();
        config.NewConfig<AttendanceEntity, AttendanceWithStudentResponseDTO>();
    }
}

