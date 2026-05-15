using CSharpStudentCourseManagementDesignPatterns.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Manager
{
    public class ShortCourseStudentManager : IStudentManager
    {
        public double GetAdmissionFee(Student std)
        {
            return std.AdmissionFee;
        }

        
        public double GetDevelopmentFeeAmount(Student std)
        {
            return std.SemesterFee * std.DevelopmentFeePctn;  // 4000 * 0.15 = 600
        }

        // TotalFee = AdmissionFee + SemesterFee + DevelopmentFee
        public double GetTotalFee(Student std)

        {
      
                       return std.AdmissionFee + std.SemesterFee + GetDevelopmentFeeAmount(std); // 3000 + 4000 + 600 = 7600
        }
    }
}
