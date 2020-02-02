using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CompilerProgram
{
    public class interpreter
    {
        private List<string> lines = new List<string>(); //List for containing all lines
        private Dictionary<string, float> variable = new Dictionary<string, float>(); // Dictionary for variables


        // Executes interpretater
        public interpreter(string LinesIn)
        {
            string newLinesIn = Regex.Replace(LinesIn, @"\s+", ""); //Removes White space

            string currentLine = ""; //Instansiate empty line

            //Console.WriteLine(newLinesIn);


            //Add to line until reach ;
            for (int i = 0; i < newLinesIn.Length; i++)
            {
                if (newLinesIn[i].Equals(';')) //if reached eol
                {
                    lines.Add(currentLine);
                    //Console.WriteLine(currentLine);
                    currentLine = "";
                }
                else // if not eol
                {
                    currentLine = currentLine + newLinesIn[i];
                }
            }

            // Run each line of code
            for (int i = 0; i < lines.Count; i++)
            {
                RunLine(lines[i], i);
            }
        }

        void ProcessAssignment(string[] parts)
        {

        }

        void ProcessLoop(int loopLength, int loop) 
        {
            
        }

        // Runs a line of code
        void RunLine(string line, int lineNum)
        {

            //Console.WriteLine(line);

            // Regex that splits the string based on variables/symbols/values + removes whitespace
            string[] parts = Regex.Split(line, @"(\d+(?:.\d+)?|[-^=+/()]|\w+)").Where(s => s != String.Empty).ToArray<string>(); ;

            //Console.WriteLine(parts[0]);
            //Console.WriteLine(parts[1]);
            //Console.WriteLine(parts[2]);

            if (parts[1] == "=")
            {
                ProcessAssignment(parts);
            }
            else if (parts[0] == "loop")
            {
                LoopContext loopContext = new LoopContext(int.Parse(parts[1]), lineNum);
            }
            else if (parts[0] == "if")
            {

            }


            /*List<string> parts = new List<string>();
            
            
            
            for (int i = 0; i < line.Length; i++)
            {
                if (Regex.IsMatch(line[i].ToString(), @"\d"))
                {

                }
            }
            */


            //string[] linesPart = line.Split(' ');
            /*Console.WriteLine(linesPart[0]);
            Console.WriteLine(linesPart[1]);
            Console.WriteLine(linesPart[2]);*/


        }

        void ProcessExpression()
        {

        }
    }

    public class Context
    {
        int current;
        int firstLine;


        public Context()
        {

        }
        public bool endOfContext()
        {
            return true;
        }
        // Instance of loopContext for each loop we are in
        // List for each, first or last value is current and each in order is next above
        // Have function that checks if current != condition
        // if is return firstLine and increment current
        // else end loop and remove from list
    }

    public class IfContext : Context
    {
        int condition;
        public IfContext(int condition, int firstline)
        {

        }
    }

    public class LoopContext : Context
    {
        int loopLength;
        public LoopContext(int loopLength, int firstline)
        {

        }
    }

}
