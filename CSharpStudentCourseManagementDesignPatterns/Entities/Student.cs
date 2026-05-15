using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Entities
{
    public class Student
    {
        public Student() { }

        public Student(int studentId, string name, string email,
                       StudentType type, Department dept,
                       double admissionFee, double semesterFee)
        {
            StudentId = studentId;
            Name = name;
            Email = email;
            Type = type;
            Dept = dept;
            AdmissionFee = admissionFee;
            SemesterFee = 4000;
            DevelopmentFeePctn = 0.15;   
            TotalFee = 0;
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public StudentType Type { get; set; }
        public Department Dept { get; set; }
        public double AdmissionFee { get; set; }
        public double SemesterFee { get; set; }
        public double DevelopmentFeePctn { get; set; } 
        public double TotalFee { get; set; }
    }
}
