using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Part_3
{
    //Author: Shane Doherty
    //Purpose: To replace every instance of no with yes and yes with no
    //Restrictions: None
    class Program
    {
        //Author: Shane Doherty
        //Purpose: Main - Asks the user for a string, replaces every instance of no with yes and yes with no, and displays it back to the user
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
                if (word.ToLower() == "yes")
                {
                    sReturnString += "no";
                }
                else if (word.ToLower() == "no")
                {
                    sReturnString += "yes";
                } else
                {
                    sReturnString += word;
                }
                sReturnString += " ";
            }

            Console.WriteLine(sReturnString);




        }
    }
}
