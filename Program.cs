using ProjectMangeStudent.Service;
using ProjectMangeStudent.Valid;

internal class Program
{
    private static Validation validation = new Validation();
    static void Main(string[] args)
    {
        StudentService studentService = new StudentService();

        do
        {
            Console.WriteLine("------------- Manage Student -----------");
            Console.WriteLine("---------------- Option ----------------");
            Console.WriteLine("1. View List Student.");
            Console.WriteLine("2. Create new Student.");
            Console.WriteLine("3. Update Student.");
            Console.WriteLine("4. Find Student.");
            Console.WriteLine("5. Delete Student.");
            Console.WriteLine("6. Academy Performance Student.");
            Console.WriteLine("7. DisplayAverageScorePercentages.");
            Console.WriteLine("8. PrintStudentByPerformance.");
            Console.WriteLine("9. Save to File.");
            Console.WriteLine("0. Exits.");
            Console.Write("Choose your option: ");

            int choose = validation.GetChoose();

            switch (choose)
            {
                case 1:
                    studentService.ReadStudent();
                    break;
                case 2:
                    studentService.AddStudentDemo();
                    break;
                case 3:
                    studentService.UpdateStudent();
                    break;
                case 4:
                    studentService.FindStudent();
                    break;
                case 5:
                    studentService.RemoveStudent();
                    break;
                case 6:
                    studentService.DisplayPerformace();
                    break;
                case 7:
                    studentService.DisplayAverageScorePercentages();
                    break;
                case 8:
                    studentService.PrintStudentByPerformance();
                    break;
                case 9:
                    studentService.SaveFile();
                    break;
                case 0:
                    Console.WriteLine("Exiting the program....");
                    return;
                default:
                    Console.WriteLine("Choose your option 0 --> 9.");
                    break;
            }
        } while (true);
    }
}
