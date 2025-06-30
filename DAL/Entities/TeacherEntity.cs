using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class TeacherEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; } 
        public string Email { get; set; }
        public int? Experience { get; set; }
        public string PhotoUrl {  get; set; }
        public string Bio { get; set; }
        public string Nationality { get; set; }

        public ICollection<CourseEntity> Courses { get; set; }


    }
}
