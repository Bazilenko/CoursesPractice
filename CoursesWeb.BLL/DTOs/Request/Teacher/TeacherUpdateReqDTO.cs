﻿namespace CoursesWeb.DTOs.Request.Teacher
{
    public class TeacherUpdateReqDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string Email { get; set; }
        public int? Experience { get; set; }
        public string PhotoUrl { get; set; }
        public string Bio { get; set; }
        public string Nationality { get; set; }
    }
}
