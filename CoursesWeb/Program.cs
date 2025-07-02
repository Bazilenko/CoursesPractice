using DAL.Data;
using Microsoft.EntityFrameworkCore;
using CoursesWeb.Data.BogusSeed;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CoursesManagmentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));


// Add services to the container.   


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CoursesManagmentContext>();
    await DbSeeder.SeedAsync(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
