using CSharpStudentCourseManagementDesignPatterns.Entities;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpStudentCourseManagementDesignPatterns.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> _students = new List<Student>();

        public StudentRepository()
        {
            _students = new List<Student>()
            {
                new Student()
                {
                    StudentId = 1, Name = "MD Kayum Hossain", Email = "kayum@email.com",
                    Type = StudentType.LongCourse, Dept = Department.ComputerScience,
                    AdmissionFee = 0, SemesterFee = 4000, DevelopmentFeePctn = 0.15,
                    TotalFee = 4600   // 4000 + 600
                },
                new Student()
                {
                    StudentId = 2, Name = "MD Yousuf Hossain", Email = "yousuf@email.com",
                    Type = StudentType.LongCourse, Dept = Department.Automobile,
                    AdmissionFee = 0, SemesterFee = 4000, DevelopmentFeePctn = 0.15,
                    TotalFee = 4600   // 4000 + 600
                },
                new Student()
                {
                    StudentId = 3, Name = "Mst Nusrat Akter", Email = "nusrat@email.com",
                    Type = StudentType.ShortCourse, Dept = Department.Business,
                    AdmissionFee = 3000, SemesterFee = 4000, DevelopmentFeePctn = 0.15,
                    TotalFee = 7600   // 3000 + 4000 + 600
                },
                new Student()
                {
                    StudentId = 4, Name = "MD. Saiful Islam", Email = "saiful@email.com",
                    Type = StudentType.ShortCourse, Dept = Department.ComputerScience,
                    AdmissionFee = 3000, SemesterFee = 4000, DevelopmentFeePctn = 0.15,
                    TotalFee = 7600   // 3000 + 4000 + 600
                }
            };
        }

        public IEnumerable<Student> GetStudentList() => _students;

        public Student GetStudentById(int id) =>
            _students.FirstOrDefault(s => s.StudentId == id);

        public void SaveStudent(Student student)
        {
            student.StudentId = _students.Count > 0 ? _students.Max(s => s.StudentId) + 1 : 1;
            _students.Add(student);
        }

        public void UpdateStudent(Student upStudent)
        {
            Student exStudent = GetStudentById(upStudent.StudentId);
            if (exStudent != null)
            {
                exStudent.Name = upStudent.Name;       
                exStudent.Email = upStudent.Email;
                exStudent.Type = upStudent.Type;
                exStudent.Dept = upStudent.Dept;
                exStudent.AdmissionFee = upStudent.AdmissionFee;
                exStudent.SemesterFee = upStudent.SemesterFee;
                exStudent.DevelopmentFeePctn = upStudent.DevelopmentFeePctn;
                exStudent.TotalFee = upStudent.TotalFee;
            }
        }

        public void DeleteStudent(int id)
        {
            Student std = GetStudentById(id);
            if (std != null)
                _students.Remove(std);
        }

    }
}
