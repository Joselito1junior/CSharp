using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conjunto_2.Entities
{
    class Student
    {
        public string Name { get; set; }
        public int Register { get; set; }

        HashSet<Course> Courses = new HashSet<Course>();

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
        public void RemoveCourse(Course course)
        {
            Courses.Remove(course);
        }
    }
}
