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

            List<Course> courses = new List<Course>()
            { new Course(221, "Creative Writing: Mysteries",
                new List<Student>(){ new Student(329, "Barbara Kingsolver"), new Student(923, "James Patterson") }),
              new Course(301,"History of Warfare",
                 new List<Student>() { new Student(273, "Sarah Vaughn"), new Student(692, "George Orwell") }),
              new Course(130,  "Writing for Distopian Future",
                  new List<Student>(){ new Student(451, "Ray Bradbury"), new Student(842, "Margaret Atwood") })};

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

            Student studentOne = new Student(88, "Jack Ripper", new List<Course>()
            { new Course (101, "Intro to Philosophy" ), new Course (315, "Human Anatomy" ) });
            Student studentTwo = new Student(98, "Green River", new List<Course>()
            { new Course (111, "Budgets and Planning" ), new Course ( 212, "Nautical Knot Making" )});
            Student studentThree = new Student(87, "Brother Bishop", new List<Course>()
            { new Course (301, "Criminal Prosecution"), new Course (219, "Religious Studies") });


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
            { {55, new Course (55, "BeBop and Rythym") },
              {34, new Course (34, "Folk Music Instruments") },
              {88, new Course(88, "Synthesizer and Electronic Music")},
              {69, new Course(69, "From Poodle Skirts to Mini Skirts")}};


            List<Student> moreStudents = new List<Student>()
            { new Student (27, "Janis Joplin", new List<Grade>()
            {new Grade {courseNumber = 34, courseGrade = 89}, new Grade {courseNumber = 69, courseGrade = 78} }) ,
                new Student(70, "David Bowie", new List<Grade>()
            { new Grade {courseNumber = 88, courseGrade = 97}, new Grade{courseNumber = 69, courseGrade = 77}}),
            new Student (64, "Thelonius Monk", new List<Grade>()
            { new Grade {courseNumber = 55, courseGrade = 93}, new Grade {courseNumber = 34, courseGrade = 72 }})};

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