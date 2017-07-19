using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public Course(int _courseID, string _name)
        {
            CourseId = _courseID;
            Name = _name;
        }

        public Course(int _courseID, string _name, List<Student> _students)
        {
            CourseId = _courseID;
            Name = _name;
            Students = _students;
        }
    }
}