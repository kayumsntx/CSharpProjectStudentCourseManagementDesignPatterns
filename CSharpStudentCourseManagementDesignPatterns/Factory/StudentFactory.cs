using CSharpStudentCourseManagementDesignPatterns.Entities;
using CSharpStudentCourseManagementDesignPatterns.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Factory
{
    public abstract class StudentFactory
    {
        protected Student _student;  

        protected StudentFactory(Student student)
        {
            _student = student;  
        }

        public abstract IStudentManager Create(); 

        public Student ProcessStudent()
        {
           
            IStudentManager manager = Create();

            if (manager == null)
            {
                throw new Exception("Manager could not be created");
            }

           
            _student.TotalFee = manager.GetTotalFee(_student);

          
            return _student;
        }
    }
}
