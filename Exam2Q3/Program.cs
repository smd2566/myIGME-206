using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q3
{
    //Author: Shane Doherty
    //Purpose: Program - Creates Tuples and stores them inside a sorted list based on an equation
    //Restrictions: None

    class Program
    {
        //Author: Shane Doherty
        //Purpose: Main - Creates the sorted list, and runs for loops to store Tuples inside of it
        //Restrictions: None
        static void Main(string[] args)
        {
            double w = 0;
            double x = 0;
            double y = 0;
            double z = 0;

            int nW = 0;
            int nX = 0;
            int nY = 0;

            //sorted list creation

            SortedList<(double, double, double), double> sortedList = new SortedList<(double, double, double), double>();
            
            for (w = -2; w <= 0; w += .2, ++nW)
            {
                w = Math.Round(w, 1);

                for (x = 0; x <= 4; x += 0.1, ++nX)
                {

                    x = Math.Round(x, 1);

                    for (y = -1; y <= 1; y += 0.1, ++nY)
                    {

                        y = Math.Round(y, 1);


                        z = 4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - (8 * w) + 7;
                        


                        z = Math.Round(z, 3);

                        //Tuple creation
                        (double, double, double) zFunc = (w, x, y);
                        sortedList.Add(zFunc, z);
                        
                    }
                }
            }

        }
    }
}

