using CSharpStudentCourseManagementDesignPatterns.Entities;
using CSharpStudentCourseManagementDesignPatterns.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns.Factory
{
    public class LongCourseFactory : StudentFactory
    {
        public LongCourseFactory(Student student) : base(student) { }

        public override IStudentManager Create()
        {
            return new LongCourseStudentManager();
        }
    }
}
