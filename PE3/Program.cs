using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE3
{
    class Program
    {
        //Author: Shane Doherty
        //Purpose: Main: To find the product of 4 numbers entered by the user
        //Restrictions: None
        static void Main(string[] args)
        {
            double dProduct = 1;
            double dStoredNumber = 0;


            //Purpose: Asks the user for an input and checks if the input is a valid number, stops the program otherwise.
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Please enter an integer" + "(" + (i + 1)
                    + ")");

                string input = Console.ReadLine();
                try
                {
                    dStoredNumber = Convert.ToDouble(input);
                } catch
                {
                    
                    Console.WriteLine("Incorrect format: Only enter a NUMBER");
                    --i;
                    break;
                    
                }
                
                    dProduct = dProduct * dStoredNumber;
                
 
            }
            
            Console.WriteLine("The product of these values is " + dProduct);

        }
    }
}
