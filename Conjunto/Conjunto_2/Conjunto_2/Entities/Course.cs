using System;
using System.Collections.Generic;

namespace Conjunto_2.Entities
{
    class Course
    {
        public string Name { get; set; }

        HashSet<Student> Students = new HashSet<Student>();

        public Course(string name)
        {
            Name = name;
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        public HashSet<Student> GetStudents()
        {
            return Students;
        }
    }
}
