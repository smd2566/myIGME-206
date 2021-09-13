using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Part_4
{
    //Author: Shane Doherty
    //Purpose: To place double quotes around every word in a user entered string
    //Restrictions: None
    class Program
    {
        //Author: Shane Doherty
        //Purpose: Main - Asks the user for a string input, places double quotes around every word in the string, and displays the result back to the user
        //Restrictions: None
        static void Main(string[] args)
        {
            string sUserInput = null;
            string sReturnString = null;
            Console.WriteLine("Please enter a string");
            sUserInput = Console.ReadLine();
            string[] words = sUserInput.Split(' ');

            foreach (string word in words)
            {
                sReturnString += "\"";
                sReturnString += word;
                sReturnString += "\"";
                sReturnString += " ";
            }

            Console.WriteLine(sReturnString);
        }
    }
}
