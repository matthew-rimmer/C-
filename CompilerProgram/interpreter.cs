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
        
        private Dictionary<string, float> variables = new Dictionary<string, float>(); // Dictionary for variables

        private Stack<Context> contexts = new Stack<Context>();

        int currentLineNumber;

        int bracketCount;

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
                else if (newLinesIn[i].Equals('}') || newLinesIn[i].Equals('{'))
                {
                    lines.Add(currentLine + newLinesIn[i]);
                    //Console.WriteLine(currentLine);
                    currentLine = "";
                }
                else // if not eol
                {
                    currentLine = currentLine + newLinesIn[i];
                }
            }

            // Run each line of code
            for (currentLineNumber = 0; currentLineNumber < lines.Count; currentLineNumber++)
            {
                RunLine(lines[currentLineNumber], currentLineNumber);
            }
        }

        void ProcessAssignment(string[] parts)
        {
            if (variables.ContainsKey(parts[0]))
            {
                int rightSide = processRightSide(parts);
                variables[parts[0]] = rightSide;

            }
            else
            {
                int rightSide = processRightSide(parts);
                variables.Add(parts[0], rightSide);
            }
        }

        int processRightSide(string[] parts)
        {
            return 0;
        }

        // Runs a line of code
        void RunLine(string line, int lineNum)
        {

            Console.WriteLine(line);

            // Regex that splits the string based on variables/symbols/values + removes whitespace
            string[] parts = Regex.Split(line, @"(\d+(?:.\d+)?|[-^=+/()]|\w+)").Where(s => s != String.Empty).ToArray<string>(); ;

            //Console.WriteLine(parts[0]);
            //Console.WriteLine(parts[1]);
            //Console.WriteLine(parts[2]);

            if (parts.Length == 0)
            {

            }
            else if (parts[0] == "}")
            {
                Console.WriteLine("Hey I've reached the end of something");

                if (contexts.Peek() is LoopContext)
                {
                    LoopContext lcontext = (LoopContext)contexts.Pop();

                    Console.WriteLine("Hey, it's a loop!");

                    if (lcontext.checkContext())
                    {
                        Console.WriteLine("Let's do it again!");
                        currentLineNumber = lcontext.firstLine;
                        Console.WriteLine(lcontext.current);
                        contexts.Push(lcontext);
                    }
                    else
                    {
                        Console.WriteLine("Oh hey, this loop is done");
                    }
                }
                else if (contexts.Peek() is IfContext)
                {
                    Console.WriteLine("Hey, it's an if!");
                    contexts.Pop();
                }
            }
            else if (parts[1] == "=")
            {
                Console.WriteLine("Hey I'm in an assignment");
                ProcessAssignment(parts);
            }
            else if (parts[0] == "loop")
            {
                Console.WriteLine("Hey I've found a loop");
                LoopContext loopContext = new LoopContext(int.Parse(parts[2]), lineNum);
                contexts.Push(loopContext);

            }
            else if (parts[0] == "if")
            {
                Console.WriteLine("Hey I've found an if");
                IfContext forContext = new IfContext(parts[2], lineNum);
                contexts.Push(forContext);
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
        public int current;
        public int firstLine;
        public int bracketCount;


        public Context()
        {

        }
        public bool checkContext()
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
        string condition;
        public IfContext(string condition, int firstline)
        {

        }
    }

    public class LoopContext : Context
    {
        int loopLength;
        public LoopContext(int loopLength, int firstline)
        {
            this.loopLength = loopLength;
            this.firstLine = firstline;
        }

        new public bool checkContext()
        {
            if (current == loopLength -1)
            {
                return false;
            }
            else
            {
                current += 1;
                return true;
            }
        }

        public void addBracket()
        {
            bracketCount += 1;
        }
    }

}
