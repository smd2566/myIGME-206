using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8_Part_1
{
    //Author: Shane Doherty
    //Purpose: To use an equation and store the values in a 3D array
    //Restrictions: Crashes upon running
    class Program
    {
        //Author: Shane Doherty
        //Purpose: Main: Calculates the x, y and z values based on the trinomial equation
        //Restrictions: Crashes upon running
        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            double i = 0;
            double j = 0;
            double[,,] aArray = new double[20, 30, 600];

            for (i = -1; i <= 20; i++)
            {
                x = .1 * i;
                aArray[(int)i, (int)j, (int)z] = x;
                for (j = 1; j <= 30; j++)
                {
                    y = .1 * j;
                    aArray[(int)i, (int)j, (int)z] = y;

                    z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;
                    aArray[(int)i, (int)j, (int)z] = z;

                }
            }

        }
    }
}
