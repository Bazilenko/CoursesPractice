using AutoMapper;
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

namespace CoursesWeb.Automapper
{
    public class Mapping : Profile
    {
        public Mapping() {
            //Responces
            CreateMap<TeacherEntity, TeacherMiniResponseDTO>().ReverseMap();
            CreateMap<AssignmentEntity, AssignmentFullResponseDTO>().ReverseMap();
            CreateMap<AttendanceEntity, AttendanceFullResponseDTO>().ReverseMap();
            CreateMap<CourseEntity, CourseFullResponseDTO>().ReverseMap();
            CreateMap<LessonEntity, LessonMiniResponseDTO>().ReverseMap();
            CreateMap<StudentEntity, StudentMiniResponseDTO>().ReverseMap();
            CreateMap<SubmissionEntity, SubmissionMiniResposeDTO>().ReverseMap();

            //Requests
            CreateMap<TeacherEntity, TeacherCreateReqDTO>().ReverseMap();
            CreateMap<TeacherEntity, TeacherUpdateReqDTO>().ReverseMap();
            CreateMap<AssignmentEntity, CreateAssignmentReqDTO>().ReverseMap();
            CreateMap<AttendanceEntity, AttendanceCreateReqDTO>().ReverseMap();
            CreateMap<AttendanceEntity, AttendanceUpdateReqDTO>().ReverseMap();
            CreateMap<CourseEntity, CreateCourseReqDTO>().ReverseMap();
            CreateMap<CourseEntity, CourseUpdateReqDTO>().ReverseMap();
            CreateMap<EnrollmentEntity, EnrollmentCreateReqDTO>().ReverseMap();
            CreateMap<EnrollmentEntity, EnrollmentUpdateReqDTO>().ReverseMap();
            CreateMap<LessonEntity, LessonCreateReqDTO>().ReverseMap();
            CreateMap<LessonEntity, LessonUpdateReqDTO>().ReverseMap();
            CreateMap<StudentEntity, StudentCreateReqDTO>().ReverseMap();
            CreateMap<StudentEntity, StudentUpdateReqDTO>().ReverseMap();
            CreateMap<SubmissionEntity, SubmissionCreateReqDTO>().ReverseMap();
            CreateMap<SubmissionEntity, StudentUpdateReqDTO>().ReverseMap();


        }
    }
}
