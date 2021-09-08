using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE6
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bValid = true;
            int iStoredNumber = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
            Console.WriteLine(randomNumber);

            for (int i = 0; i < 8; i++)
            {
                Console.Write("Turn #" + (i + 1) + ": ");
                bValid = true;
                string input = Console.ReadLine();
                try
                {
                    iStoredNumber = Convert.ToInt32(input);
                }
                catch
                {

                    Console.WriteLine("Incorrect format: Only enter an INTEGER");
                    --i;
                    bValid = false;


                }
                if (iStoredNumber < 0)
                {
                    Console.WriteLine("Incorrect format: The number cannot be lower than 0");
                    --i;
                    bValid = false;
                }
                if (iStoredNumber > 100)
                {
                    Console.WriteLine("Incorrect format: The number cannot be greater than 100");
                    --i;
                    bValid = false;
                }

                if (bValid == true)
                {
                    if (iStoredNumber == randomNumber)
                    {
                        Console.WriteLine("You guessed the correct answer in " + (i + 1) + " turns!");
                        break;
                    }
                    if (iStoredNumber < randomNumber)
                    {
                        Console.WriteLine("Too low");
                    }
                    if (iStoredNumber > randomNumber)
                    {
                        Console.WriteLine("Too high");
                    }

                }

                if (i == 7)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You ran out of turns! The correct answer was " + randomNumber);
                    break;
                }


            }
        }
    }
}
