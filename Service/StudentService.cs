using ProjectMangeStudent.Enitities;
using ProjectMangeStudent.Valid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangeStudent.Service
{
    internal class StudentService
    {
        Validation validation = new Validation();
        public static List<Student> listStudents = new List<Student>();
        public static int currentId = 1;
        public string filename = "C:\\Users\\damha\\Downloads\\ProjectMangeStudent\\ProjectMangeStudent\\students.json";
        public void AddStudent()
        {
            try
            {
                var id = currentId;
                var name = validation.GetName();
                var birthdate = validation.GetDate();
                var address = validation.GetAddress();
                var height = validation.GetHeight();
                var weight = validation.GetWeight();
                var code = validation.GetCode();
                var school = validation.GetSchool();
                var year = validation.GetYearDate();
                var average = validation.GetAverage();
                var s = new Student(id, name, birthdate, address, height, weight, code, school, year, average);

                s.UpdatePerformance();
                listStudents.Add(s);
                currentId ++;
                Console.WriteLine("Student add Successfull. ");
                
            }catch(Exception ex) 
            { 
                Console.WriteLine($"Error add Student{ex.Message}"); 
            }
            Console.WriteLine();
            SaveFile();
            //ReadStudent();
        }

        public void AddStudentDemo()
        {
                var student = new Student(1, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 2 );
                var student1 = new Student(2, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 3 );
                var student2 = new Student(3, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 6 );
                var student3 = new Student(4, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 6.5 );
                var student4 = new Student(5, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 7.5 );
                var student5 = new Student(5, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 8 );
                var student6 = new Student(5, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 9.5 );
                var student7 = new Student(5, "hao", DateOnly.Parse("02/11/2003"), "", 175, 75, "HE176449", "FPT", 2003, 10 );
            student.UpdatePerformance();
            student1.UpdatePerformance();
            student2.UpdatePerformance();
            student3.UpdatePerformance();
            student4.UpdatePerformance();
            student5.UpdatePerformance();
            student6.UpdatePerformance();
            student7.UpdatePerformance();
            listStudents.Add(student);
            listStudents.Add(student1);
            listStudents.Add(student2);
            listStudents.Add(student3);
            listStudents.Add(student4);
            listStudents.Add(student5);
            listStudents.Add(student6);
            listStudents.Add(student7);
            SaveFile();
        }

        public bool checkNullListStudent()
        {
            if (listStudents == null || !listStudents.Any())
            {
                Console.WriteLine("List Student dosen't have information!!!");
                Console.WriteLine();
                return false;
            }
            return true;
        }
        public void ReadStudent()
        {
            if(!checkNullListStudent())
            {
                return;
            }
            
            Console.WriteLine("List information Student: ");
            foreach (Student student in listStudents)
            {
               Console.WriteLine(student + $" Academic Performance: {student.Performance}");
            }
            
            SaveFile();
        }

        public int GetIdStudent()
        {
            return validation.GetInt();
        }

        public Student? GetStudent()
        {
            int id = GetIdStudent();
            return listStudents.Find(s => s.Id ==  id);
        }

        public void FindStudent()
        {
            Console.Write("Enter your id Student you want to find: ");
            int chooseId = GetIdStudent();

            var student = listStudents.Find(s => s.Id == chooseId);

            if (student != null)
            {
                Console.WriteLine(student.ToString());
            }
            else
            {
                Console.WriteLine($"Id {chooseId} student not found!!!");
            }
        }

        public void UpdateStudent()
        {
            Console.Write("Enter your id Student you want to update information: ");
            int findId = GetIdStudent();

            var student = listStudents.Find(s => s.Id == findId);

            if(student != null)
            {
                Console.WriteLine("Enter new details. ");
                student.Name = validation.GetName();
                student.Birthday = validation.GetDate();
                student.Address = validation.GetAddress();
                student.Height = validation.GetHeight();
                student.Weight = validation.GetWeight();
                student.Code = validation.GetCode();
                student.School = validation.GetSchool();
                student.StartDate = validation.GetYearDate();
                student.Average = validation.GetAverage();
                student.UpdatePerformance();
                SaveFile();
                Console.WriteLine("Student update successfully.");
            }else
            {
                Console.WriteLine($"Id {findId} student not found!!!");
            }
            Console.WriteLine();
        }

        public void RemoveStudent()
        {
            Console.Write("Enter your id Student you want to remove: ");
            var student = GetStudent();

            if (student != null)
            {
                int index = listStudents.IndexOf(student);
                for (int i = index; i < listStudents.Count - 1; i++)
                {
                    listStudents[i] = listStudents[i + 1];
                }
                listStudents.RemoveAt(listStudents.Count - 1);
                Console.WriteLine("Student was Deleted!");
                SaveFile();
            }
            else
            {
                Console.WriteLine("Not found Student you want to remmove");
            }
        }

        public void DisplayPerformace()
        {
            if (!checkNullListStudent())
            {
                return;
            }

            int totalStudent = listStudents.Count;
            var performaces = listStudents.
                                GroupBy(s => s.Performance).
                                Select(group => new
                                {
                                    Performace = group.Key,
                                    Count = group.Count(),
                                    Percentage = (double)group.Count() / totalStudent * 100
                                }
                                ).
                                OrderByDescending(x => x.Percentage).
                                ToList();
            Console.WriteLine("Academy Performace sorted by heighest percentage");
            foreach (var performace in performaces)
            {
                Console.WriteLine($"{performace.Performace} : {performace.Count} student(s), {performace.Percentage} %");
            }
        }

        public void DisplayAverageScorePercentages()
        {
            if (!checkNullListStudent())
            {
                return;
            }

            Dictionary<double, int> averageScore = new Dictionary<double, int>();
            foreach (var student in listStudents)
            {
                double average = student.Average;
                if (averageScore.ContainsKey(average))
                {
                    averageScore[average]++;
                }else
                {
                    averageScore[average] = 1;
                }
            }

            int totalStudent = listStudents.Count;
            Console.WriteLine("Average Score: ");
            foreach (var entry in averageScore) 
            {
                double score = entry.Key;
                int count = entry.Value;
                double percentage = (double)count / totalStudent * 100;
                Console.WriteLine($"{score} : {percentage:F2}%");
            }
        }

        public void PrintStudentByPerformance()
        {
            if (!checkNullListStudent())
            {
                return;
            }
            Console.WriteLine("Enter the academic performance you want to search for (Poor, Weak, Average, Good, Excellent, Outstanding): ");

            string? input = Console.ReadLine();

            if (Enum.TryParse(input, true, out @enum performance))
            {
                var filteredStudent = listStudents.Where(s => s.Performance == performance).ToList();

                if (filteredStudent.Any())
                {
                    Console.WriteLine($"List of students with performance '{performance}':");
                    foreach (var student in filteredStudent)
                    {
                        Console.WriteLine(student);
                    }
                }
                else
                {
                    Console.WriteLine($"No students found with performance '{performance}'.");
                }
            }
            else
            {
                Console.WriteLine("Invalid academic performance input. Please enter one of the valid options.");
            }
        }

        public void SaveFile()
        {
            FileServices.SaveToFile(filename, new ObservableCollection<Student>(listStudents));
        }
    }
}
