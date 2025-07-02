using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AssignmentEntity
    {
        public int Id { get; set; }
        public string Tittle {  get; set; }
        public string Description {  get; set; }
        public DateTime DueDate { get; set; }
        public int LessonId { get; set; }
        public LessonEntity Lesson { get; set; }
        public ICollection<SubmissionEntity> Submissions { get; set; }
    }
}
