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



            Console.Write("Enter your favorite color: \t");

            color = Console.ReadLine();

            Console.Write("Enter your favorite number: \t");

            sNumber = Console.ReadLine();

            favnum = Convert.ToInt32(sNumber);




        }
    }
}
