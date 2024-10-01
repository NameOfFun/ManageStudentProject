using ProjectMangeStudent.Enitities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;

namespace ProjectMangeStudent.Service
{
    internal class FileServices
    {
        public static List<Student> ReadFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    using (var reader = new StreamReader(filename))
                    {
                        string jsonContent = reader.ReadToEnd();
                        var students = JsonSerializer.Deserialize<List<Student>>(jsonContent);
                        return students ?? new List<Student>();
                    }
                }
                else
                {
                    Console.WriteLine("File not found, returning an empty list.");
                    return new List<Student>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
                return new List<Student>();
            }
        }

        public static void SaveToFile(string filename, ObservableCollection<Student> students)
        {
            try
            {
                Console.WriteLine($"Saving to file: {filename}");  
                using (var writer = new StreamWriter(filename))
                {
                    string jsonContent = JsonSerializer.Serialize(students);
                    writer.Write(jsonContent);
                }
                Console.WriteLine("Data successfully saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

    }
}
