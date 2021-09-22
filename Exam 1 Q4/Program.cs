using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace Exam_1_Q4
{
    //Author: Shane Doherty
    //Purpose: Program - A simple and silly question game with a static answer that the user must guess
    //Restrictions: None
    class Program
    {

        static Timer timeOutTimer;
        static string sAnswer = null;
        static bool bTimeOut = false;
        static bool bValid = true;

        //Author: Shane Doherty
        //Purpose: Main - Asks the user for a question number, then asks the question and waits for the response.
        //Tells the user if their response matched the designated answer in the given time limit.
        //Then asks if the user wants to play again.
        //Restrictions: None

        static void Main(string[] args)
        {
        start:
            bValid = true;
            string sInput = null;
            string sUserResponse = null;
            string sAgain = null;
            string sQuestion = null;

            int iStoredNumber = 0;

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Choose your question (1-3): ");
                sInput = Console.ReadLine();
                try
                {
                    iStoredNumber = Convert.ToInt32(sInput);
                }
                catch
                {

                    Console.WriteLine("Incorrect format: Only enter a NUMBER (1-3)");
                    --i;


                }
                if (iStoredNumber > 3 || iStoredNumber < 1)
                {
                    Console.WriteLine("Incorrect format: Only enter a NUMBER (1-3)");
                }

            }


            if (iStoredNumber == 1)
            {
                sQuestion = "What is your favorite color?";
                sAnswer = "black";
            }
            if (iStoredNumber == 2)
            {
                sQuestion = "What is the answer to life, the universe and everything?";
                sAnswer = "42";

            }
            if (iStoredNumber == 3)
            {
                sQuestion = "What is the airspeed velocity of an unladen swallow?";
                sAnswer = "What do you mean? African or European swallow?";

            }


            timeOutTimer = new Timer(5000);
            ElapsedEventHandler elapsedEventHandler;
            elapsedEventHandler = new ElapsedEventHandler(TimesUp);
            timeOutTimer.Elapsed += elapsedEventHandler;


            Console.WriteLine("You have 5 seconds to answer the following question:");
            Console.WriteLine(sQuestion);
            timeOutTimer.Start();
            sUserResponse = Console.ReadLine();

            while (bValid == true)
            {
                if (sUserResponse == sAnswer && bTimeOut == false)
                {
                    Console.WriteLine("Well done!");
                    timeOutTimer.Stop();
                    bValid = false;
                }
                else
                {
                    Console.WriteLine("The answer is: " + sAnswer);
                    timeOutTimer.Stop();
                    bValid = false;
                }
            }

            do
            {
                Console.Write("Do you want to play again? ");

                sAgain = Console.ReadLine();

                if (sAgain.ToLower().StartsWith("y"))
                {
                    goto start;
                }
                else if (sAgain.ToLower().StartsWith("n"))
                {
                    break;
                }
            } while (true);

        }

        //Author: Shane Doherty
        //Purpose: TimesUp - A method to be called when the time limit has expired. Displays the correct ansswer, stops the timer, and in turn ends the game.
        //Restrictions: None
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            timeOutTimer.Stop();
            Console.WriteLine("Your time is up!");
            Console.WriteLine("The answer is: " + sAnswer);
            bTimeOut = true;
            bValid = false;
            Console.WriteLine("Please press enter.");

        }
    }
}
