using DAL.Data;
using Microsoft.EntityFrameworkCore;
using CoursesWeb.Data.BogusSeed;
using CoursesWeb.Repositories.Contracts;
using CoursesWeb.UOW.Contract;
using CoursesWeb.UOW;
using CoursesWeb.Repositories;
using CoursesWeb.Services.Contracts;
using CoursesWeb.Services;
using MapsterMapper;
using Mapster;
using FluentValidation.AspNetCore;
using CoursesWeb.DTOs.Request.TeacherEntity;
using CoursesWeb.BLL.FluentValidation;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CoursesManagmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


// Add services to the container.   


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ILessonRepository, LessonRepository>();
builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddSingleton(TypeAdapterConfig.GlobalSettings);
builder.Services.AddScoped<IMapper, ServiceMapper>();

var config = TypeAdapterConfig.GlobalSettings;
new Mapping().Register(config);

builder.Services.AddScoped<ITeacherService, TeachersService>();

builder.Services
    .AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<TeacherCreateDTOValidator>();
    });

var app = builder.Build();

//Bogus
//using (var scope = app.Services.CreateScope())
//{
//    var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
//    await DbSeeder.SeedAsync(unitOfWork);
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
