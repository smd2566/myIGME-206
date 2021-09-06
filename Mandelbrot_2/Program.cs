using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;

            bool bValid = true;
            double dStoredNumber = 0;

            double dLowerLimitX = 0;
            double dUpperLimitX = 0;
            double dIncX = 0;

            double dLowerLimitY = 0;
            double dUpperLimitY = 0;
            double dIncY = 0;

            


            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Please enter an integer for the lower limit of X");
                }
                if (i == 1)
                {
                    Console.WriteLine("Please enter an integer for the upper limit of X");
                }
                if (i == 2)
                {
                    Console.WriteLine("Please enter an integer for the incremementer of X (The default is 0.05)");
                }
                if (i == 3)
                {
                    Console.WriteLine("Please enter an integer for the lower limit of Y");
                }
                if (i == 4)
                {
                    Console.WriteLine("Please enter an integer for the upper limit of Y");
                }
                if (i == 5)
                {
                    Console.WriteLine("Please enter an integer for the incrementer of Y (The default is .03)");
                }

                bValid = true;
                string input = Console.ReadLine();
                try
                {
                    dStoredNumber = Convert.ToDouble(input);
                }
                catch
                {

                    Console.WriteLine("Incorrect format: Only enter a NUMBER");
                    --i;
                    bValid = false;


                }
                if (bValid == true)
                {
                    if (i == 0)
                    {
                        dLowerLimitX = dStoredNumber;
                        
                    }
                    if (i == 1)
                    {
                        dUpperLimitX = dStoredNumber;
                        if (dUpperLimitX > dLowerLimitX)
                        {
                            Console.WriteLine("The lower limit must start from a higher value than the upper limit. Please enter a new value");
                            i--;
                        }
                    }
                    if (i == 2)
                    {
                        dIncX = dStoredNumber;
                    }
                    if (i == 3)
                    {
                        dLowerLimitY = dStoredNumber;
                        
                    }
                    if (i == 4)
                    {
                        dUpperLimitY = dStoredNumber;
                        if (dUpperLimitY < dLowerLimitY)
                        {
                            Console.WriteLine("The lower limit must start from a higher value than the upper limit. Please enter a new value");
                            i--;
                        }

                    }
                    if (i == 5)
                    {
                        dIncY = dStoredNumber;

                    }

                }

            }













            for (imagCoord = dLowerLimitX; imagCoord >= dUpperLimitX; imagCoord -= dIncX)
            {
                for (realCoord = dLowerLimitY; realCoord <= dUpperLimitY; realCoord += dIncY)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}

