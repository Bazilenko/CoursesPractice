using Bogus;
using CoursesWeb.UOW;
using CoursesWeb.UOW.Contract;
using DAL.Entities;

public class DbSeeder
{
    public static async Task SeedAsync(IUnitOfWork unitOfWork)
    {
        var random = new Random();
        var faker = new Faker();

        // Teachers
        var teacherFaker = new Faker<TeacherEntity>()
            .RuleFor(t => t.FirstName, f => f.Person.FirstName)
            .RuleFor(t => t.LastName, f => f.Person.LastName)
            .RuleFor(t => t.MiddleName, f => f.Random.Bool() ? f.Person.FullName : null)
            .RuleFor(t => t.PhotoUrl, f => f.Person.Avatar)
            .RuleFor(t => t.Email, f => f.Internet.Email())
            .RuleFor(t => t.Bio, f => f.Lorem.Sentence(10))
            .RuleFor(t => t.Experience, f => f.Random.Int(1, 20))
            .RuleFor(t => t.Nationality, f => f.Address.Country());

        var teachers = teacherFaker.Generate(20);
        await unitOfWork.Teachers.AddRangeAsync(teachers);
        await unitOfWork.CompleteAsync(default);

        // Courses
        var courseFaker = new Faker<CourseEntity>()
            .RuleFor(c => c.Title, f => $"{f.PickRandom("Intro to", "Advanced", "Masterclass in")} {f.PickRandom("Grammar", "Speaking", "Cybersecurity")}")
            .RuleFor(c => c.Description, f => f.Lorem.Sentence(10))
            .RuleFor(c => c.Level, f => f.PickRandom("A1", "A2", "B1", "B2", "C1"))
            .RuleFor(c => c.Price, f => f.Random.Decimal(1000, 50000))
            .RuleFor(c => c.QuantityOfLessons, f => f.Random.Int(10, 100))
            .RuleFor(c => c.Discount, f => f.Random.Decimal(5, 80));

        var courses = courseFaker.Generate(10);
        await unitOfWork.Courses.AddRangeAsync(courses);
        await unitOfWork.CompleteAsync(default);

        // Students
        var studentFaker = new Faker<StudentEntity>()
            .RuleFor(s => s.Name, f => f.Person.UserName)
            .RuleFor(s => s.Email, f => f.Person.Email);

        var students = studentFaker.Generate(30);
        await unitOfWork.Students.AddRangeAsync(students);
        await unitOfWork.CompleteAsync(default);

        // Enrollments
        var enrollments = new List<EnrollmentEntity>();
        foreach (var student in students)
        {
            var selectedCourses = courses.OrderBy(_ => random.Next()).Take(2).ToList();
            foreach (var course in selectedCourses)
            {
                enrollments.Add(new EnrollmentEntity
                {
                    StudentId = student.Id,
                    CourseId = course.Id,
                    EnrolledAt = DateTime.Now.AddDays(-random.Next(5, 60))
                });
            }
        }
        await unitOfWork.Enrollments.AddRangeAsync(enrollments);
        await unitOfWork.CompleteAsync(default);

        // Lessons
        var lessons = new List<LessonEntity>();
        foreach (var course in courses)
        {
            for (int i = 1; i <= 5; i++)
            {
                var teacher = teachers[random.Next(teachers.Count)];
                lessons.Add(new LessonEntity
                {
                    Tittle = $"Lesson {i} - {course.Level}",
                    VideoTitle = faker.Lorem.Sentence(6),
                    VideoUrl = faker.Internet.Url(),
                    AudioTitle = faker.Lorem.Words(3).Aggregate((a, b) => $"{a} {b}"),
                    AudioUrl = faker.Internet.UrlWithPath("mp3"),
                    TextContent = faker.Lorem.Paragraphs(2),
                    Date = DateTime.Now.AddDays(-i * 7),
                    CourseId = course.Id,
                    TeacherId = teacher.Id
                });
            }
        }
        await unitOfWork.Lessons.AddRangeAsync(lessons);
        await unitOfWork.CompleteAsync(default);

        // Attendance
        var attendances = new List<AttendanceEntity>();
        foreach (var lesson in lessons)
        {
            var studentsInCourse = enrollments
                .Where(e => e.CourseId == lesson.CourseId)
                .Select(e => e.StudentId)
                .ToList();

            foreach (var studentId in studentsInCourse)
            {
                attendances.Add(new AttendanceEntity
                {
                    LessonId = lesson.Id,
                    StudentId = studentId,
                    Status = random.Next(0, 100) < 85 ? "Присутній" : "Відсутній"
                });
            }
        }
        await unitOfWork.Attendances.AddRangeAsync(attendances);
        await unitOfWork.CompleteAsync(default);

        // Assignments
        var assignments = lessons.Select(lesson => new AssignmentEntity
        {
            LessonId = lesson.Id,
            Tittle = $"HW for {lesson.Tittle}",
            Description = faker.Lorem.Sentence(8),
            DueDate = lesson.Date.AddDays(3)
        }).ToList();

        await unitOfWork.Assignments.AddRangeAsync(assignments);
        await unitOfWork.CompleteAsync(default);

        // Submissions
        var submissions = new List<SubmissionEntity>();
        foreach (var assignment in assignments)
        {
            var courseId = lessons.First(l => l.Id == assignment.LessonId).CourseId;
            var studentsInCourse = enrollments
                .Where(e => e.CourseId == courseId)
                .Select(e => e.StudentId)
                .ToList();

            foreach (var studentId in studentsInCourse)
            {
                if (random.Next(0, 100) < 80)
                {
                    submissions.Add(new SubmissionEntity
                    {
                        AssignmentId = assignment.Id,
                        StudentId = studentId,
                        SubmittedAt = assignment.DueDate.AddDays(-random.Next(0, 2)),
                        Grade = random.Next(1, 10).ToString()
                    });
                }
            }
        }
        await unitOfWork.Submissions.AddRangeAsync(submissions);
        await unitOfWork.CompleteAsync(default);
    }

}