using CSharpStudentCourseManagementDesignPatterns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Repository
{
    public interface IStudentRepository
    {
        void SaveStudent(Student student);
        IEnumerable<Student> GetStudentList();
        Student GetStudentById(int id);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);

    }
}
