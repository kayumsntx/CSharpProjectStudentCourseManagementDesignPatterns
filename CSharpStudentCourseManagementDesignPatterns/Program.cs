using CSharpStudentCourseManagementDesignPatterns.Entities;
using CSharpStudentCourseManagementDesignPatterns.Factory;
using CSharpStudentCourseManagementDesignPatterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpStudentCourseManagementDesignPatterns
{
    internal class Program
    {
        static IStudentRepository repo = new StudentRepository();
        private static Student student;

        static void Main(string[] args)
        {
			try
			{
				DoTask();
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}
			finally
			{
				Console.ReadLine();
			}
        }

        private static void DoTask()
        {
            while(true)
			{
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t------------------- Student Course Management------------------");
                Console.WriteLine("".PadLeft(32) + "---------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t|| 1. Create || 2. Read || 3. Update || 4. Delete || 5. Exit ||");
                Console.WriteLine("".PadLeft(32) + "---------------------------------------------------------------");
                Console.Write("\n".PadLeft(35) + "Enter choice: ");
                var input = Console.ReadLine();

                if (input == "5") break;
                ExecuteChoice(input);
            }

        }

        private static void ExecuteChoice(string choice)
        {
            switch (choice)
            {
                case "1": Create(); break;
                case "2": Read(); break;
                case "3": Update(); break;
                case "4": Delete(); break;

               
            }
        }

        private static void Create()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Type (1: LongCourse, 2: ShortCourse): ");
            StudentType type = (StudentType)Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Department (1: ComputerScience, 2: Business, 3: Automobile): ");
            Department dept = (Department)Convert.ToInt32(Console.ReadLine());

            double admissionFee = 0.0;

            if (type == StudentType.ShortCourse)
            {
                admissionFee = 3000;  
            }
            else
            {
                admissionFee = 0;  
            }

       
            Student student = new Student(0, name, email, type, dept, admissionFee, 4000);

         
            StudentFactory factory = type == StudentType.ShortCourse
                ? (StudentFactory)new ShortCourseFactory(student)
                : new LongCourseFactory(student);

       
            factory.ProcessStudent();

           
            repo.SaveStudent(student);

            Console.WriteLine($"Student saved successfully! Total Fee: {student.TotalFee:C}");
            Read();
        }




        private static void Delete()
        {
            Console.Write("Enter ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = repo.GetStudentById(id);
            if (student == null) { Console.WriteLine("Student not found!"); return; }
            repo.DeleteStudent(id);
            Console.WriteLine($"Student '{student.Name}' (ID: {id}) deleted successfully!");
            Read();


        }

        private static void Update()
        {
            Console.Write("Enter Student ID to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid ID format.");
                return;
            }

            var student = repo.GetStudentById(id);
            if (student == null) { Console.WriteLine("Student not found!"); return; }

            Console.Write($"New Name ({student.Name}): ");
            student.Name = Console.ReadLine();

            Console.Write($"New Email ({student.Email}): ");
            student.Email = Console.ReadLine();

            Console.WriteLine($"New Department ({student.Dept}) - (1: ComputerScience, 2: Business, 3: Automobile): ");
            student.Dept = (Department)Convert.ToInt32(Console.ReadLine());

            Console.Write("New Type (1: LongCourse, 2: ShortCourse): ");
            student.Type = (StudentType)Convert.ToInt32(Console.ReadLine());

            if (student.Type == StudentType.ShortCourse)
            {
                student.AdmissionFee = 3000;
              
            }
            else
            {
                student.AdmissionFee = 0;
                Console.WriteLine("No admission fee for Long Course.");
            }

            
            student.DevelopmentFeePctn = 0.15;

            StudentFactory factory = student.Type == StudentType.ShortCourse
                ? (StudentFactory)new ShortCourseFactory(student)
                : new LongCourseFactory(student);

            factory.ProcessStudent();
            repo.UpdateStudent(student);
            Console.WriteLine("Student updated successfully!");
            Read();
        }


        

        private static void Read()
        {
            var studentList = repo.GetStudentList();

            Console.WriteLine("\n" + new string('=', 160));
            Console.WriteLine("\t\t\t\t\t\t\t\tStudent Course Details List");
            Console.WriteLine(new string('=', 160));

            string fmt = "|| {0,-3} || {1,-18} || {2,-18} || {3,-12} || {4,-18} || {5,-15} || {6,-15} || {7,-15} || {8,-10} ||";

            Console.WriteLine(fmt, "ID", "Name", "Email", "Course Type", "Department",
                "Admission Fee", "Semester Fee", "Development Fee", "Total Fee");
            Console.WriteLine(new string('-', 160));

            if (!studentList.Any())
            {
                Console.WriteLine("\t\t\t\tNo Record found");
            }
            else
            {
                foreach (var s in studentList)
                {
                    string admissionFee = s.Type == StudentType.LongCourse
                        ? "0.00"
                        : s.AdmissionFee.ToString("F2");

              
                    double developmentFeeAmount = s.SemesterFee * s.DevelopmentFeePctn;

                    Console.WriteLine(fmt,
                        s.StudentId,
                        s.Name,
                        s.Email,
                        s.Type,
                        s.Dept,
                        admissionFee,
                        s.SemesterFee.ToString("F2"),
                        developmentFeeAmount.ToString("F2"), 
                        s.TotalFee.ToString("F2"));
                }
            }

            Console.WriteLine(new string('=', 160));
        }


    }
}
