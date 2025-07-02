using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class SubmissionEntity
    {
        public int Id { get; set; }
        public DateTime SubmittedAt {  get; set; }
        public string Grade {  get; set; }
        public int AssignmentId { get; set; }
        public AssignmentEntity Assignment { get; set; }
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
    }
}
