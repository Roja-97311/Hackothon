using System;

namespace SampleFrameworkApp
{
    class Utilities
    {
       
            internal static string prompt(string question)
            {
                Console.WriteLine(question);
                return Console.ReadLine();
            }
            internal static int GetNumber(String question)
            {
                return int.Parse(prompt(question));
            }
        }

 }

