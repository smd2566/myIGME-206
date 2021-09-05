using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4_Part_1
{
    class Program
    {

        //Author: Shane Doherty
        //Purpose: Main - Asks user for two numbers. Rejects input if both numbers are greater than 10. Displays both numbers to user when the condition is met.
        //Restrictions: None
        static void Main(string[] args)
        {
            bool bValid = true;
            int iStoredNumber = 0;
            int[] myIntArray = new int[2];
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Please enter an integer" + "(" + (i + 1)
                    + ")");
                bValid = true;
                string input = Console.ReadLine();
                try
                {
                    iStoredNumber = Convert.ToInt32(input);
                }
                catch
                {

                    Console.WriteLine("Incorrect format: Only enter a NUMBER");
                    --i;
                    bValid = false;


                }
                if (bValid == true)
                {
                    myIntArray[i] = iStoredNumber;
                }

                if (i == 1)
                {
                    if (myIntArray[0] > 10 && myIntArray[1] > 10)
                    {
                        Console.WriteLine("Both numbers cannot be greater than 10. Enter two new numbers.");
                        myIntArray = new int[2];
                        i = -1;
                    } else
                    {
                        Console.WriteLine("Your numbers are " + myIntArray[0] + " and " + myIntArray[1]);
                    }

                }

            }

        }
    }
}
