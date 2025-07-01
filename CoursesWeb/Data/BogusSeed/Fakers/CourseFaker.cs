using Bogus;
using DAL.Entities;

namespace CoursesWeb.Data.BogusSeed.Fakers
{
    public class CourseFaker : Faker<CourseEntity>
    {
        public CourseFaker() {
            RuleFor(c => c.Title, f =>
            {
                var prefix = f.PickRandom("Intro to", "Advanced", "Masterclass in", "Essentials of", "Complete Guide to");
                var topic = f.PickRandom("Grammar", "Speaking", "Learning", "Cybersecurity", "Vocabulary", "Reading");
                return $"{prefix} {topic}";
            });

            RuleFor(c => c.Description, f => f.Lorem.Sentence(10));
            RuleFor(c => c.Level, f => f.PickRandom(new[] {"A1", "A2", "B1", "B2", "C1"}));
            RuleFor(c => c.Description, f => f.Lorem.Sentence(10));
            RuleFor(c => c.Price, f => f.Random.Decimal(1000, 50000));
            RuleFor(c => c.QuantityOfLessons, f => f.Random.Int(10, 100));
            RuleFor(c => c.Discount, f => f.Random.Decimal(5, 80));
            
        }
        
    }
}
