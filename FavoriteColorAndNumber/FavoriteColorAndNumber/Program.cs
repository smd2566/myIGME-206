using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavoriteColorAndNumber
{
    //Class: Program
    //Author: Shane Doherty
    //Purpose: Console Read/Write and Exception-handling exercise
    //Restrictions: None
    static class Program
    {
        //Class: Program
        //Author: Shane Doherty
        //Purpose: Main
        //Restrictions: None
        static void Main(string[] args)
        {
            //string to hold favorite color
            string color = null;
            //string to hold favorite number
            int favnum = 0;
            //check to see if entered value is valid
            bool bValid = false;
            //loop counter
            int i = 0;
            //Placeholder before the number is converted
            string sNumber;


            //Asks the user for their favorite color and writes it
            Console.Write("Enter your favorite color: \t");
            color = Console.ReadLine();

            //Asks the user for their favorite number and converts it
            Console.Write("Enter your favorite number: \t");
            sNumber = Console.ReadLine();

            //Crashes the program if the user enters a string instead of an int
            favnum = Convert.ToInt32(sNumber);




        }
    }
}
