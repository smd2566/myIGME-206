using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //Compile Time Error. Added semicolon to fix
            //int i = 0
            int i = 0;

            string allNumbers = null;

            // loop through the numbers 1 through 10
            for (i = 1; i < 10; ++i)
            {
                // declare string to hold all numbers
                //Logical Error: This should be declared outside of the for loop
                //string allNumbers = null;

                // output explanation of calculation
                //Compile Time Error. Replaced Console.Write with Console.WriteLine. Also added quotation marks around -1.
                //Console.Write(i + "/" + i - 1 + " = ");
                Console.WriteLine(i + "/" + i + "- 1" + " = ");

                // output the calculation based on the numbers
                //Run-time error: If i = 1, the program crashes as it cannot divide by 0. Added an if check to solve the issue.
                //Console.WriteLine(i / (i - 1));

                if (i != 1)
                {
                    Console.WriteLine(i / (i - 1));
                } else
                {
                    Console.WriteLine("null: Cannot divide by 0");
                }
                

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //Logical Error: This is not needed as the for loop already increases the counter by using ++i
                //i = i + 1;
            }

            // output all numbers which have been processed
            //Compile Time error: Added a + so allNumbers can be displayed correctly
            //Console.WriteLine("These numbers have been processed: " allNumbers);
            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}
