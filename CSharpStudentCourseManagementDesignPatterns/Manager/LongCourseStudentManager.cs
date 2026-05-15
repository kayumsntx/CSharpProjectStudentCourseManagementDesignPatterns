using CSharpStudentCourseManagementDesignPatterns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Manager
{
    public class LongCourseStudentManager : IStudentManager
    {
        public double GetAdmissionFee(Student std)
        {
            return 0;
        }

        public double GetDevelopmentFeeAmount(Student std)
        {
            return std.SemesterFee * std.DevelopmentFeePctn;  // 4000 * 0.15 = 600
        }

       
        public double GetTotalFee(Student std)

        {
            
            return std.AdmissionFee+ std.SemesterFee + GetDevelopmentFeeAmount(std);  // 4000 + 600 = 4600
        }
    }
}
