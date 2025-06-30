using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<EnrollmentEntity> Enrollments { get; set; }
        public ICollection<AttendanceEntity> Attendances { get; set; }
        public ICollection<SubmissionEntity> Submissions { get; set; }

    }
}
