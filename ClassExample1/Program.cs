using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassExample1
{
    class Program
    {
        static void Main()
        {
            //DECLARATIONS
            //This program will allow the end-user to select course they would like to add to their schedule and output the cost of the course.
            string[ , ] classes = { 
                                    { "CWEB1010", "CWEB1111", "CWEB1000", "CWEB1011", "GRAPH1100" },
                                    { "CWEB2400", "SENG2000", "SENG2000", "SENG2100", "SENG2130" },
                                    { "GENGS3000", "GENS3100", "WRIT3000", "CWEB3100", "CWEB3000" },
                                    { "SENG5000", "SENG4100", "BCSA2000", "BCSA3000", "HIST4000" }
                                  };
            double[,] courseTuition = {
                                        { 1200.00, 1200.00, 1400.00, 1400.00, 1600.00 },
                                        { 1300.00, 1300.00, 1500.00, 1500.00, 1700.00 },
                                        { 1400.00, 1400.00, 1600.00, 1600.00, 1800.00 },
                                        { 1500.00, 1500.00, 1700.00, 1700.00, 1900.00 }

                                     };
            double[,] creditHour = {
                                    {2.0,3.0,1.0,2.0, 4.0 },
                                    {3.0,2.0,1.0,2.0, 4.0 },
                                    {4.0,1.0,1.0,2.0, 4.0 },
                                    {1.0,3.0,1.0,2.0, 5.0 }

                                    };
            string userInput, termInput, name; //Declaring a variable
            int row, column, accurateRow, accurateColumn;
            bool keepGoing = true;
            double sum;
            string sentinel;
            List<String> courseList = new List<String>();
            List<Double> tuitionList = new List<Double>();
            Dictionary<string, double> term = new Dictionary<string, double>();
            ConsoleKeyInfo key;


            //calling welcome message
            welcome(out key);
            //check to see if key is equal to enter
            while (key.Key == ConsoleKey.Enter)
            {
                name = getName();
                termInput = getTerm();
                outputCourses(ref classes);

                /*  Console.WriteLine("Please enter the desired term you would like to add courses to");
                termInput = Console.ReadLine();*/

                do
                {
                    getData(out row, out column);
                    outputInfo(ref row, ref column);

                    //Adding data to list
                    courseList.Add(classes[row, column]);
                    tuitionList.Add(courseTuition[row, column]);
                    getPrimer();
                    keepGoing = getPrimerInner();


                 } while (keepGoing);

                //Iterating through the list to output courses added to list
                foreach (var i in courseList)
                {
                    Console.WriteLine($"You have added the following courses {i}");
                }

                Console.WriteLine("Thanks for using this program your program had a total number of {0}", courseList.Count);
                sum = tuitionList.Sum();

                term.Add(termInput, sum);
                Console.WriteLine(" You have entered courses for {0},for a total amount of tution of  {1}", term.Keys.ElementAt(0), term.Values.ElementAt(0).ToString("C"));

            }
        }//end of main
        public static void welcome(out ConsoleKeyInfo key)
        {
            Console.WriteLine("welcome, this program will allow you to enter a term and add courses to the term.");
            Console.WriteLine("Let's get started, please enter your first term");
            key = Console.ReadKey();
        }
        public static void getPrimer(out ConsoleKeyInfo key)
        {
            Console.WriteLine("welcome, this program will allow you to enter a term and add courses to the term.");
            Console.WriteLine("Let's get started, please enter your first term");
            key = Console.ReadKey();
        }

        public static bool getPrimerInner()
        {
            string sentinel;
            bool keepGoing;
            Console.WriteLine("If you would like to add another course, please enter Y to continue or N to exit program");
            sentinel = Console.ReadLine();
            sentinel = sentinel.ToUpper();
            //Defensive programming


            if (sentinel == "Y")
            {
                keepGoing = true;
            }
            else
            {
                keepGoing = false;
            }
        }
        public static string getName()
        {
            //Declarations
            string name;
            Console.WriteLine("Please enter your name for this schedule");
            name = Console.ReadLine();

            return name;
        }
        public static string getTerm()
        {
            string term;
            Console.WriteLine("Please enter the term you'd like to add to courses");
            term = Console.ReadLine();

            return term;

        }
        public static void outputCourses(ref string[,] classes)
        {
            //Output courses to console
            for (var x = 0; x < classes.GetLength(0); x++)
            {
                Console.Write($" Term {x + 1}:   ");
                for (var w = 0; w < classes.GetLength(1); w++)
                {
                    Console.Write($" {x + 1}{w + 1}) {classes[x, w]}"); //Interpolation
                }
                Console.WriteLine(" \n");
            }
        } // closing brace for outer loop
        public static void getData(out int row, out int column)
        {
            //Declarations
            string userInput;

            //Ask the user to select a course
            Console.WriteLine("Please enter a course number from the list above");
            userInput = Console.ReadLine();
            row = Int32.Parse(userInput.Substring(0, 1));
            column = Convert.ToInt32(userInput.Substring(1, 1));
            row = row - 1;
            column = column - 1;
        }
        public static void outputInfo(ref int row, ref int column, ref string [,] classes, ref double[,] courseTuition)
        {
            Console.WriteLine($" You have selected {classes[row, column]} that will cost {courseTuition[row, column].ToString("c")}");

        }
    }
}
