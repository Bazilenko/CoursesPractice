using DAL.Data;
using Microsoft.EntityFrameworkCore;
using CoursesWeb.Data.BogusSeed;
using CoursesWeb.Repositories.Contracts;
using CoursesWeb.UOW.Contract;
using CoursesWeb.UOW;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CoursesManagmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


// Add services to the container.   


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ITeacherRepository, ITeacherRepository>();
builder.Services.AddScoped<IAssignmentRepository, IAssignmentRepository>();
builder.Services.AddScoped<IAttendanceRepository, IAttendanceRepository>();
builder.Services.AddScoped<ICourseRepository, ICourseRepository>();
builder.Services.AddScoped<ISubmissionRepository, ISubmissionRepository>();
builder.Services.AddScoped<IStudentRepository, IStudentRepository>();
builder.Services.AddScoped<ILessonRepository, ILessonRepository>();
builder.Services.AddScoped<IEnrollmentRepository, IEnrollmentRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

//Bogus

//using (var scope = app.Services.CreateScope())
//{
//   var context = scope.ServiceProvider.GetRequiredService<CoursesManagmentContext>();
//    await DbSeeder.SeedAsync(context);
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
