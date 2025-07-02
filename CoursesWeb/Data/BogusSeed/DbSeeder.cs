using Bogus;
using Bogus.DataSets;
using CoursesWeb.Data.BogusSeed.Fakers;
using DAL.Data;
using DAL.Entities;

namespace CoursesWeb.Data.BogusSeed
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(CoursesManagmentContext context)
        {
          

            var random = new Random();
            int Teacherid = 1;
            

            var teacherFaker = new Faker<TeacherEntity>()
                
                .RuleFor(t => t.FirstName, t => t.Person.FirstName)
                .RuleFor(t => t.LastName, t => t.Person.LastName)
                .RuleFor(t => t.MiddleName, f => f.Random.Bool() ? f.Person.FullName : null)
                .RuleFor(t => t.PhotoUrl, t => t.Person.Avatar)
                .RuleFor(t => t.Email, f => f.Internet.Email())
                .RuleFor(t => t.Bio, f => f.Lorem.Sentence(10))
                .RuleFor(t => t.Experience, f => f.Random.Int(1, 20))
                .RuleFor(t => t.Nationality, f => f.Address.Country());

            var teachers = teacherFaker.Generate(20);
            context.Teachers.AddRange(teachers);
            int Coursesid = 1;

            
            var courseFaker = new Faker<CourseEntity>()
                
                .RuleFor(c => c.Title, f =>
                {
                    var prefix = f.PickRandom("Intro to", "Advanced", "Masterclass in", "Essentials of", "Complete Guide to");
                    var topic = f.PickRandom("Grammar", "Speaking", "Learning", "Cybersecurity", "Vocabulary", "Reading");
                    return $"{prefix} {topic}";
                })

            .RuleFor(c => c.Description, f => f.Lorem.Sentence(10))
            .RuleFor(c => c.Level, f => f.PickRandom(new[] { "A1", "A2", "B1", "B2", "C1" }))
            .RuleFor(c => c.Description, f => f.Lorem.Sentence(10))
            .RuleFor(c => c.Price, f => f.Random.Decimal(1000, 50000))
            .RuleFor(c => c.QuantityOfLessons, f => f.Random.Int(10, 100))
            .RuleFor(c => c.Discount, f => f.Random.Decimal(5, 80));
            var courses = courseFaker.Generate(10);
            context.Courses.AddRange(courses);

            int Studentid = 1;
          

            var studentFaker = new Faker<StudentEntity>()
                .RuleFor(s => s.Name, f => f.Person.UserName)
                .RuleFor(s => s.Email, f => f.Person.Email); 
            var students = studentFaker.Generate(30);
            context.Students.AddRange(students);
            context.SaveChanges();


            int Enrollmentid = 1;
            var enrollments = new List<EnrollmentEntity>();
            var enrollmentId = 1;

            foreach (var student in students)
            {
                // Випадково перемішай курси для кожного студента
                var shuffledCourses = courses
                    .OrderBy(_ => random.Next())
                    .Take(2)
                    .ToList();

                foreach (var course in shuffledCourses)
                {
                    enrollments.Add(new EnrollmentEntity
                    {
                        StudentId = student.Id,
                        CourseId = course.Id,
                        EnrolledAt = DateTime.Now.AddDays(-random.Next(5, 60))
                    });
                }
            }
            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
            Faker faker = new Faker();
            int Lessonid = 1;
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
                        Course = course,
                        TeacherId = teacher.Id,
                        Teacher = teacher
                    });
                }
            }
            context.Lessons.AddRange(lessons);
            context.SaveChanges();

            int Attendanceid = 1;
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
            context.Attendances.AddRange(attendances);
            context.SaveChanges();

           
            int Assignmentid = 1;
            var assignments = new List<AssignmentEntity>();
            foreach (var lesson in lessons)
            {
                assignments.Add(new AssignmentEntity
                {
                    LessonId = lesson.Id,
                    Tittle = $"HW for {lesson.Tittle}",
                    Description = new Faker().Lorem.Sentence(8),
                    DueDate = lesson.Date.AddDays(3)
                });
            }
            context.Assignment.AddRange(assignments);
            context.SaveChanges();

            int Submissionid = 1;
            var submissions = new List<SubmissionEntity>();
            foreach (var assignment in assignments)
            {
                var studentsInCourse = enrollments
                    .Where(e => e.CourseId == lessons.First(l => l.Id == assignment.LessonId).CourseId)
                    .Select(e => e.StudentId)
                    .ToList();

                foreach (var studentId in studentsInCourse)
                {
                    if (random.Next(0, 100) < 80) // 80% учнів здають
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
            context.Submissions.AddRange(submissions);
            context.SaveChanges();
        }
    }
    }

