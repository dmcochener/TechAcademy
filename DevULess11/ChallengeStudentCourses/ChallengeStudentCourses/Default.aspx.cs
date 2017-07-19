using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */

            string result = "";
            //Create students
            Student firstStudent = new Student(329, "Barbara Kingsolver");
            Student secondStudent = new Student(923, "James Patterson");
            Student thirdStudent = new Student(273, "Sarah Vaughn");
            Student fourthStudent = new Student(692, "George Orwell");
            Student fifthStudent = new Student(451, "Ray Bradbury");
            Student sixthStudent = new Student(842, "Margaret Atwood");

            List<Student> classOneStudents = new List<Student>()
            { firstStudent, secondStudent};

            List<Student> classTwoStudents = new List<Student>()
            { thirdStudent, fourthStudent};

            List<Student> classThreeStudents = new List<Student>()
            { fifthStudent, sixthStudent};

            List<Course> courses = new List<Course>()
            { new Course{CourseId = 221, Name = "Creative Writing: Mysteries", Students = classOneStudents},
              new Course{CourseId = 301, Name = "History of Warfare", Students = classTwoStudents},
              new Course{CourseId = 130, Name = "Writing for Distopian Future", Students = classThreeStudents}
            };

            foreach (Course course in courses)
            {
                result += string.Format("Course {0}: {1} <br />", course.CourseId, course.Name);
                foreach (Student student in course.Students)
                    result += string.Format("&nbsp;&nbsp;Student {0}: {1} <br />", student.StudentId, student.Name); 
            }

            resultLabel.Text = result;
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */

            string result = "";

            Student studentOne = new Student(88, "Jack Ripper");
            Student studentTwo = new Student(98, "Green River");
            Student studentThree = new Student(87, "Brother Bishop");

            Course courseOne = new Course { CourseId = 101, Name = "Intro to Philosophy" };
            Course courseTwo = new Course { CourseId = 111, Name = "Budgets and Planning" };
            Course courseThree = new Course { CourseId = 212, Name = "Nautical Knot Making" };
            Course courseFour = new Course { CourseId = 301, Name = "Criminal Prosecution" };
            Course courseFive = new Course { CourseId = 315, Name = "Human Anatomy" };
            Course courseSix = new Course { CourseId = 219, Name = "Religious Studies" };

            studentOne.Courses = new List<Course> { courseOne, courseFive };
            studentTwo.Courses = new List<Course> { courseTwo, courseThree };
            studentThree.Courses = new List<Course> { courseFour, courseSix };

            Dictionary<int, Student> students = new Dictionary<int, Student>()
            {
                {studentOne.StudentId, studentOne }, {studentTwo.StudentId, studentTwo},
                {studentThree.StudentId, studentThree }
            };

            foreach (var student in students)
            {
                result += String.Format("Student {0}: {1} <br />", student.Key, student.Value.Name);
                foreach (Course course in student.Value.Courses)
                    result += String.Format("&nbsp;&nbsp;Course {0}: {1} <br />", course.CourseId, course.Name);
            }

            resultLabel.Text = result;
        }

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */

            string result = "";

            Dictionary<int, Course> moreCourses = new Dictionary<int, Course>()
            { {55, new Course {CourseId = 55, Name = "BeBop and Rythym"} },
              {34, new Course{CourseId = 34, Name = "Folk Music Instruments"} },
              {88, new Course{CourseId = 88, Name = "Synthesizer and Electronic Music"} },
              {69, new Course{CourseId = 69, Name = "From Poodle Skirts to Mini Skirts"} }
            };

            List<Grade> gradeJanis = new List<Grade>()
            {new Grade {courseNumber = 34, courseGrade = 89}, new Grade {courseNumber = 69, courseGrade = 78} };
            List<Grade> gradeBowie = new List<Grade>()
            { new Grade {courseNumber = 88, courseGrade = 97}, new Grade{courseNumber = 69, courseGrade = 77}};
            List<Grade> gradeMonk = new List<Grade>()
            { new Grade {courseNumber = 55, courseGrade = 93}, new Grade {courseNumber = 34, courseGrade = 72 }};

            List<Student> moreStudents = new List<Student>()
            { new Student (27, "Janis Joplin", gradeJanis) , new Student(70, "David Bowie", gradeBowie),
            new Student (64, "Thelonius Monk", gradeMonk)};

            foreach (var student in moreStudents)
            {
                result += String.Format("Student {0}: {1} <br />",student.StudentId, student.Name);
                foreach (var grade in student.Grades)
                {
                    Course currentCourse;
                    if (moreCourses.TryGetValue(grade.courseNumber, out currentCourse))
                    {
                        result += String.Format("&nbsp;&nbsp;Enrolled In: {0}, Grade - {1} <br />", currentCourse.Name, grade.courseGrade);
                    };

                }
            }

            resultLabel.Text = result;
        }
    }
}