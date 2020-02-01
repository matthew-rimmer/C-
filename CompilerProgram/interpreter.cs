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

        public interpreter(string LinesIn)
        {
            string newLinesIn = Regex.Replace(LinesIn, @"\s+", "");

            string currentLine = "";

            //Console.WriteLine(newLinesIn);

            for (int i = 0; i < newLinesIn.Length; i++)
            {
                if (newLinesIn[i].Equals(';'))
                {
                    lines.Add(currentLine);
                    //Console.WriteLine(currentLine);
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
            //Console.WriteLine(line);
            string[] parts = Regex.Split(line, @"(\d+(,\d+)*(?:.\d+)?(?:[eE][-+]?[0-9]+)?|[-^+/()]|\w+)").Where(s => s != String.Empty).ToArray<string>(); ;

            Console.WriteLine(parts[0]);
            Console.WriteLine(parts[1]);
            Console.WriteLine(parts[2]);
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
}
