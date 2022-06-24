using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    public class StudentService : IStudentService
    {
        public List<Student> Students { get; set; }

        public StudentService()
        {
            Students = new List<Student>()
            {
                new Student
                {
                    IdStudent = 1,
                    FirstName = "Jakub",
                    LastName = "Nowak",
                    Avatar = "https://gravatar.com/avatar/fc95a2144e41a53cc55ba75383a8a632?s=400&d=robohash&r=x",
                    BirthDate = DateTime.Parse("2000-04-04"),
                    Studies = "Computer-Science"
                },
                 new Student
                {
                    IdStudent = 2,
                    FirstName = "Anna",
                    LastName = "Kowalska",
                    Avatar = "https://gravatar.com/avatar/40bdac2ab6e152c005e08ba96ff4dea0?s=400&d=robohash&r=x",
                    BirthDate = DateTime.Parse("2000-11-22"),
                    Studies = "Math"
                },
                 new Student
                {
                    IdStudent = 3,
                    FirstName = "Kasia",
                    LastName = "Kowalska",
                    Avatar = "https://gravatar.com/avatar/0544b7428fe4e689d7c8af00551a4106?s=400&d=robohash&r=x",
                    BirthDate = DateTime.Parse("2000-02-22"),
                    Studies = "E-business"
                },
                 new Student
                {
                    IdStudent = 4,
                    FirstName = "Dawid",
                    LastName = "Korona",
                    Avatar = "https://gravatar.com/avatar/06b8670c320ff3ae1aab89a0a24a0af5?s=400&d=robohash&r=x",
                    BirthDate = DateTime.Parse("2000-04-10"),
                    Studies = "Marketing"
                },
                 new Student
                {
                    IdStudent = 5,
                    FirstName = "Domonic",
                    LastName = "Stones",
                    Avatar = "https://gravatar.com/avatar/64f46d76a827b90ad88d08592cd7b37b?s=400&d=robohash&r=x",
                    BirthDate = DateTime.Parse("2001-12-02"),
                    Studies = "Math"
                },
                 new Student
                {
                    IdStudent = 6,
                    FirstName = "Christian",
                    LastName = "Dior",
                    Avatar = "https://gravatar.com/avatar/260ee96d2153600b62dd9c58c9268629?s=400&d=robohash&r=x",
                    BirthDate = DateTime.Parse("1997-07-12"),
                    Studies = "Computer-Science"
                }
            };
        }


        public void DeleteStudent(int id)
        {
            Student student = Students.FirstOrDefault(e => e.IdStudent == id);
            Students.Remove(student);
        }

        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(e => e.IdStudent == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return Students;
        }

      

     
    }
}
