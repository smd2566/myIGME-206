using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEQ1
{
    //Author: Shane Doherty
    //Purpose: Program - Asks the user for a string and then relays how many of each letter is in the string
    //Restrictions: None
    class Program
    {
        //Author: Shane Doherty
        //Purpose: Main - Counts the amount of each letter in the string through foreach loops and compares the character to the alphabet string
        //Restrictions: None
        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            string sUserInput = null;
            int charCount = 0;
            Console.WriteLine("Please enter a string");
            sUserInput = Console.ReadLine();
            sUserInput = sUserInput.ToLower();

            foreach (char c in alphabet)
            {
                foreach (char k in sUserInput)
                {
                    if (k == c)
                    {
                        charCount++;
                    }
                }
                Console.WriteLine("Number of " + c + " in entered string: " + charCount);
                charCount = 0;
            }
        }
    }
}
