using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChallengeStudentCourses
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        public List<Grade> Grades { get; set; }

        public Student(int _studentId, string _name)
        {
            StudentId = _studentId;
            Name = _name;
        }

        public Student(int _studentId, string _name, List<Course> _courses)
        {
            StudentId = _studentId;
            Name = _name;
            Courses = _courses;
        }

        public Student(int _studentId, string _name, List<Grade> _grades)
        {
            StudentId = _studentId;
            Name = _name;
            Grades = _grades;
        }
    }
}