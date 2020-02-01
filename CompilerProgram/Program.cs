using System;

namespace CompilerProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string testString = @"x = 5;
            y = 1;";

            interpreter interp = new interpreter(testString);

            Console.ReadLine();
        }
    }
}
