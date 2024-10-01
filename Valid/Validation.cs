using ProjectMangeStudent.Enitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangeStudent.Valid
{
    public class Validation
    {
        public const int MaxLength = 299;
        public const int MinLength = 1;
        public const int MaxNameLength = 99;  
        public static readonly DateOnly MinDate = new DateOnly(1900, 1, 1);
        public static readonly DateOnly MaxDate = DateOnly.FromDateTime(DateTime.Now);
        public const double MaxWeight = 1000.0;
        public const double MinWeight = 5.0;
        public const double MaxHeight = 300.0;
        public const double MinHeight = 50.0;
        public const int MaxCode = 10;
        public const int MaxSchool = 199;
        public const double MaxAverage = 10.0;
        public const double MinAverage = 0.0;

        // Method to check name validity
        public string CheckName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Name cannot be Empty or Whitespace";
            }
            if (name.Length < MinLength)
            {
                return $"Name must be at least {MinLength} characters.";
            }
            if (name.Length > MaxNameLength)  
            {
                return $"Name cannot exceed {MaxNameLength} characters.";
            }

            // To check user enter number 
            if(!name.All(n => char.IsLetter(n)))
            {
                return "Name can only contaain alphabetic characters.";
            }
            return "Valid";
        }

        // Method to get a valid name
        public string GetName()
        {
            string? name;
            string validation;

            do
            {
                Console.Write("Enter your name: ");
                name = Console.ReadLine();

                validation = CheckName(name);

                if (validation != "Valid")
                {
                    Console.WriteLine(validation);  
                }

            } while (validation != "Valid");

            return name != null ? name : ""; 
        }

        // Method to check Date valid
        public string CheckDate(string? inputDate, out DateOnly date)
        {
            string[] formats = { "MM/dd/yyyy", "dd/MM/yyyy" };
            date = default;

            if(string.IsNullOrWhiteSpace(inputDate))
            {
                return "Date cannot be Empty or Whitespace";
            }

            if (!DateOnly.TryParseExact(inputDate, formats, out date))
            {
                return "Invalid date format. Please use MM/dd/yyyy or dd/MM/yyyy";
            }
            if(date < MinDate ||  date > MaxDate)
            {
                return $"date must be between {MinDate:dd/MM/yyyy} to {MaxDate:dd/MM/yyyy}";
            }
            
            return "Valid";
        }
        // Method to get a valid Date 
        public DateOnly GetDate()
        {
            DateOnly date;
            string validation;
            string? inputDate;

            do
            {
                Console.Write("Enter your birthdate (dd/MM/yyyy) or (MM/dd/yyyy): ");
                inputDate = Console.ReadLine();

                validation = CheckDate(inputDate, out date);
                if(validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return date;
        }

        // Method to check address validity
        public string CheckAddress(string? address)
        {
            if (address.Length > MaxLength)
            {
                return $"Name cannot exceed {MaxLength} characters.";
            }
            return "Valid";
        }

        // Method to get a valid Address 
        public string GetAddress()
        {
            string? address;
            string validation;

            do
            {
                Console.Write("Enter the Address: ");
                address = Console.ReadLine();
                
                validation = CheckAddress(address);

                if(validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return address != null ? address : "";
        }

        // Method to check double 
        public string CheckHeight(string? inputlength, out double length)
        {
            bool inValid = double.TryParse(inputlength, out length);

            if(!inValid)
            {
                return "Invalid input. Please enter a nummeric value";
            }

            if(length < MinHeight || length > MaxHeight)
            {
                return $"Your Height must be betteween {MinHeight} to {MaxHeight}";
            }
            return "Valid";
        }

        public double GetHeight()
        {
            double height;
            string validation;
            string? inputLength;
            do
            {
                Console.Write("Enter your Height: ");
                inputLength = Console.ReadLine();

                validation = CheckHeight(inputLength, out height);
                if( validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return height;
        }

        // Method to check double 
        public string CheckWeight(string? inputlength, out double weight)
        {
            bool inValid = double.TryParse(inputlength, out weight);

            if (!inValid)
            {
                return "Invalid input. Please enter a nummeric value";
            }

            if (weight < MinWeight || weight > MaxWeight)
            {
                return $"Your Weight must be betteween {MinWeight} to {MaxWeight}";
            }
            return "Valid";
        }

        public double GetWeight()
        {
            double weight;
            string validation;
            string? inputLength;
            do
            {
                Console.Write("Enter your Weight: ");
                inputLength = Console.ReadLine();

                validation = CheckWeight(inputLength, out weight);
                if (validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return weight;
        }

        // Method to Check Code validation
        public string CheckCode(string? code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return "Code cannot be Empty or Whitespace";
            }
            if(code.Length < MinLength || code.Length > MaxCode)
            {
                return $"Code must be between {MinLength} and {MaxCode}";
            }
            return "Valid";
        }

        public string GetCode()
        {
            string? code;
            string validation;
            do
            {
                Console.Write("Enter your Code: ");
                code = Console.ReadLine();

                validation = CheckCode(code);
                if (validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return code != null ? code : "";
        }

        // Method to check School validation
        public string CheckSchool(string? school)
        {
            if (string.IsNullOrWhiteSpace(school))
            {
                return "THe School cannot be Empty or Whitespace";
            }
            if(school.Length < MinLength ||  school.Length > MaxSchool)
            {
                return $"School must be between {MinLength} and {MaxSchool}";
            }
            return "Valid";
        }

        public string GetSchool()
        {
            string? school;
            string validation;
            do
            {
                Console.Write("Enter your School: ");
                school = Console.ReadLine();

                validation = CheckSchool(school);
                if(validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return school != null ? school : "";
        }

        //Method to check Year validation
        public string CheckYear(string? inputYear, out int year)
        {
            year = 0;

            if (string.IsNullOrWhiteSpace(inputYear))
            {
                return "Year cannot be empty or whitespace";
            }

            if(!int.TryParse(inputYear, out year))
            {
                return "Invalid year format. Please enter a valid year";
            }

            if(inputYear.Length != 4 || year < 1900 || year > MaxDate.Year)
            {
                return $"Year must be a 4 digit and between 1900 and {MaxDate.Year}";
            }
            return "Valid";
        }

        public int GetYearDate()
        {
            string? inputYear;
            string validation;
            int year;

            do
            {
                Console.Write("Enter your school years: ");
                inputYear = Console.ReadLine();

                validation = CheckYear(inputYear, out year);
                if(validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return year;
        }

        // Method to check int
        public string CheckId(string? inputId, out int id)
        {
            bool valid = int.TryParse(inputId, out id);
            if(!valid)
            {
                return "Invalid input. Please enter a numeric number";
            }

            if (id < MinLength)
            {
                return $"Please must be great than equal to {MinLength}";
            }

            
            return "Valid";
        }

        public int GetInt()
        {
            int id;
            string? inputId;
            string validation;

            do
            {
                inputId = Console.ReadLine();

                validation = CheckId(inputId, out id);
                if (validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return id;
        }

        public string CheckInt(string? inputId, out int id)
        {
            bool valid = int.TryParse(inputId, out id);
            if (!valid)
            {
                return "Invalid input. Please enter a numeric number";
            }

            return "Valid";
        }

        public int GetChoose()
        {
            int id;
            string? inputId;
            string validation;

            do
            {
                inputId = Console.ReadLine();

                validation = CheckInt(inputId, out id);
                if (validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return id;
        }

        // Method to check double Avarage validation
        public string CheckDouble(string? inputdouble, out double average)
        {
            bool validation = double.TryParse(inputdouble, out average);
            if (!validation)
            {
                return "Invalid input. Please enter the numeric number";
            }

            if(average < MinAverage ||  average > MaxAverage)
            {
                return $"Average must be between {MinAverage} and {MaxAverage}";
            }
            return "Valid";
        }

        public double GetAverage()
        {
            double average;
            string? inputAverage;
            string validation;

            do
            {
                Console.Write("Enter your Average Mark: ");
                inputAverage = Console.ReadLine();

                validation = CheckDouble(inputAverage, out average);
                if(validation != "Valid")
                {
                    Console.WriteLine(validation);
                }
            } while (validation != "Valid");
            return average;
        }
    }
}
