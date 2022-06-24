using Cw11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Services
{
    interface IStudentService
    {
        Student GetStudent(int id);
        void DeleteStudent(int id);

        IEnumerable<Student> GetStudents();
      
    }
}
