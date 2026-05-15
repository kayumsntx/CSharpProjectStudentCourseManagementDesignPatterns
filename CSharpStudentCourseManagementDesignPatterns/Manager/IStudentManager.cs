using CSharpStudentCourseManagementDesignPatterns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Manager
{
    public interface IStudentManager
    {
        double GetDevelopmentFeeAmount(Student std);  
        double GetTotalFee(Student std);
        double GetAdmissionFee(Student std);
    }
}
