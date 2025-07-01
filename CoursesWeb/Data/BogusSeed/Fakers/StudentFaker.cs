using Bogus;
using DAL.Entities;

namespace CoursesWeb.Data.BogusSeed.Fakers
{
    public class StudentFaker : Faker<StudentEntity>
    {
        public StudentFaker() {
            RuleFor(s => s.Name, f => f.Person.UserName);
            RuleFor(s => s.Email, f => f.Person.Email);
        }
    }
}
