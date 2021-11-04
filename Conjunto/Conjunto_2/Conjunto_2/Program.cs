using System;
using System.Collections.Generic;
using Conjunto_2.Entities;

namespace Conjunto_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Instructor instructor = new Instructor("Alex");

            for (int i = 0; i < 3; i++)
            {
                char name = (char)(65 + i);

                Console.Write($"How many students for course {name}? ");
                int n = int.Parse(Console.ReadLine());
                Course course = new Course(name + " ");

                for(int j = 0; j < n; j++)
                {
                    int register = int.Parse(Console.ReadLine());
                    Student student = new Student {Register = register};
                    course.AddStudent(student);
                }
                instructor.AddCourse(course);
            }

            HashSet<int> union = new HashSet<int>();
            foreach (Course c in instructor.GetCoursesByInstructor())
            {
                foreach(Student std in c.GetStudents())
                {
                    union.Add(std.Register);
                }
            }
            Console.WriteLine("Total students: " + union.Count);
        }
    }
}
