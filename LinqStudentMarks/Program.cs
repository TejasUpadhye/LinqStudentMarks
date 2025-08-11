using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqStudentMarks
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Created a sample list of students
            List<Student> students = new List<Student>
            {
                new Student { Name = "Alice", Marks = 85 },
                new Student { Name = "Bob", Marks = 45 },
                new Student { Name = "Charlie", Marks = 72 },
                new Student { Name = "David", Marks = 92 },
                new Student { Name = "Eve", Marks = 45},
                new Student { Name = "Frank", Marks = 35 }
            };
            var student45 = students.FirstOrDefault(x => x.Marks == 45);
            Console.WriteLine($"{student45.Name} - {student45.Marks}");
           // Select * from students where marks=45 orderBy 1  asc
            /* foreach (var y in student45)
             {
                 Console.WriteLine($"{y.Name} - {y.Marks}");
             }*/
            //int x = 5;
            //  Filtered students with Marks > 60 using LINQ
            var passedStudents = students.Where(x =>x.Marks > 60);

            Console.WriteLine("📋 Students who passed:");
            foreach (var y in passedStudents)
            {
                Console.WriteLine($"{y.Name} - {y.Marks}");
            }

            Console.WriteLine("\n📊 Grouping students by Grade:");

            //  Group by grade
            var grouped = students.GroupBy(z =>
            {
                if (z.Marks >= 80) return "A";
                else if (z.Marks >= 60) return "B";
                else if (z.Marks >= 40) return "C";
                else return "F";
            });

            foreach (var group in grouped)
            {
                Console.WriteLine($"\nGrade {group.Key}:");

                foreach (var student in group)
                {
                    Console.WriteLine($"  {student.Name} - {student.Marks}");
                }
            }
        }
    }
}
