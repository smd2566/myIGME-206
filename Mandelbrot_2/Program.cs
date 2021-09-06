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
            

            double dLowerLimitY = 0;
            double dUpperLimitY = 0;
            

            


            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Please enter an integer for the lower limit of X (default is 1.2)");
                }
                if (i == 1)
                {
                    Console.WriteLine("Please enter an integer for the upper limit of X (default is -1.2)");
                }
                
                if (i == 2)
                {
                    Console.WriteLine("Please enter an integer for the lower limit of Y (default is -0.6)");
                }
                if (i == 3)
                {
                    Console.WriteLine("Please enter an integer for the upper limit of Y (default is 1.77)");
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
                        dLowerLimitY = dStoredNumber;
                        
                    }
                    if (i == 3)
                    {
                        dUpperLimitY = dStoredNumber;
                        if (dUpperLimitY < dLowerLimitY)
                        {
                            Console.WriteLine("The lower limit must start from a higher value than the upper limit. Please enter a new value");
                            i--;
                        }

                    }
                    

                }

            }













            for (imagCoord = dLowerLimitX; imagCoord >= dUpperLimitX; imagCoord -= ((dLowerLimitX - dUpperLimitX) /48))
            {
                for (realCoord = dLowerLimitY; realCoord <= dUpperLimitY; realCoord += ((dUpperLimitY - dLowerLimitY) /80))
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

