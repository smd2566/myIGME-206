using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Part_2
{
    //Author Shane Doherty
    //Purpose: To reverse a user entered string
    //Restrictions: None
    class Program
    {
        //Author Shane Doherty
        //Purpose: Main: Asks the user for a string and then reverses it and displays it back to the user
        //Restrictions: None
        static void Main(string[] args)
        {
            string sUserInput = null;
            string sReturnString = null;
            Console.WriteLine("Please enter a string");
            sUserInput = Console.ReadLine();


            for (int i = sUserInput.Length; i > 0; i--)
            {
                sReturnString += sUserInput[i-1];
            }
            

            Console.WriteLine(sReturnString);





        }
    }
}
