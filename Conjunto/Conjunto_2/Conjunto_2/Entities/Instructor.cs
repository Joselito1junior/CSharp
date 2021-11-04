using System;
using System.Collections.Generic;

namespace Conjunto_2.Entities
{
    class Instructor
    {
        public string Name { get; set; }

        HashSet<Course> Courses = new HashSet<Course>();

        public Instructor(string name)
        {
            Name = name;
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }
        public void RemoveCourse(Course course)
        {
            Courses.Remove(course);
        }

        public HashSet<Course> GetCoursesByInstructor()
        {
            return Courses;
        }
    }
}
