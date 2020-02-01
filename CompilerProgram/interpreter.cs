using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CompilerProgram
{
    public class interpreter
    {
        private List<string> lines = new List<string>(); //List for containing all lines
        private Dictionary<string, float> variable = new Dictionary<string, float>(); // 

        public interpreter(string LinesIn)
        {
            string newLinesIn = Regex.Replace(LinesIn, @"\s+", "");

            string currentLine = "";
            
            for (int i = 0; i < newLinesIn.Length; i++)
            {
                if (newLinesIn[i].Equals(';'))
                {
                    lines.Add(currentLine);
                    Console.WriteLine(currentLine);
                    currentLine = "";
                }
                else
                {
                    currentLine = currentLine + newLinesIn[i];
                }
            }

            for (int i = 0; i < lines.Count; i++)
            {
                RunLine(lines[i]);
            }
        }

        void ProcessAssignment()
        {

        }

        void RunLine(string line)
        {
            //string[] linesPart = line.Split(' ');

            /*Console.WriteLine(linesPart[0]);
            Console.WriteLine(linesPart[1]);
            Console.WriteLine(linesPart[2]);*/


        }

        void ProcessExpression()
        {

        }
    }
}
