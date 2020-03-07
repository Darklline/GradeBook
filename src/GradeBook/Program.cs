using System;
using System.Collections.Generic;

namespace GradeBook
{
   
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Wojtek`s Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine(book.Name);
            System.Console.WriteLine($"{stats.Low}");
            System.Console.WriteLine($"{stats.High}");
            System.Console.WriteLine($"{stats.Average}");
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or q to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                    //...
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}