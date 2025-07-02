using Bogus;
using DAL.Entities;
namespace CoursesWeb.Data.BogusSeed.Fakers
{
    public sealed class TeacherFaker : Faker<TeacherEntity>
    {
        public TeacherFaker() {
           
            RuleFor(t => t.FirstName, t => t.Person.FirstName);
            RuleFor(t => t.LastName, t => t.Person.LastName);
            RuleFor(t => t.MiddleName, f => f.Random.Bool() ? f.Person.FullName : null);
            RuleFor(t => t.PhotoUrl, t => t.Person.Avatar);
            RuleFor(t => t.Email, f => f.Internet.Email());
            RuleFor(t => t.Bio, f => f.Lorem.Sentence(10));
            RuleFor(t => t.Experience, f => f.Random.Int(1, 20));
            RuleFor(t => t.Nationality, f => f.Address.Country());
        }
    }
}
