using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Student_Course_System.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}