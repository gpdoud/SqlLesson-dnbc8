using System;
using SqlLibrary;

namespace SqlLesson {

    class Program {

        static void Main(string[] args) {

            var sqllib = new BcConnection();
            sqllib.Connect(@"localhost\sqlexpress", "EdDb", "trusted_connection=true");
            
            MajorController.bcConnection = sqllib;

            var major = MajorController.GetMajorByPk(1);
            Console.WriteLine(major);

            var majors = MajorController.GetAllMajors();
            foreach(var m in majors) {
                Console.WriteLine(m);
            }


            StudentController.bcConnection = sqllib;

            var students = StudentController.GetAllStudents();
            foreach(var student0 in students) {
                Console.WriteLine(student0);
            }

            //var newStudent = new Student {
            //    Id = 444,
            //    Firstname = "Fred",
            //    Lastname = "Fives",
            //    SAT = 500,
            //    GPA = 5.00,
            //    MajorId = 1
            //};
            //var success = StudentController.InsertStudent(newStudent);



            var student = StudentController.GetStudentByPk(888);
            if(student == null) {
                Console.WriteLine("Student not found");
            } else {
                Console.WriteLine(student);
            }

            student.Firstname = "Charlie";
            student.Lastname = "Chan";
            var success = StudentController.UpdateStudent(student);

            var studentToDelete = new Student {
                Id = 999
            };
            //success = StudentController.DeleteStudent(999);

            students = StudentController.GetAllStudents();
            foreach(var student0 in students) {
                Console.WriteLine(student0);
            }
            sqllib.Disconnect();
        }
    }
}
