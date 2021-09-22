using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_1_Q8
{
    //Author: Shane Doherty / David Schuh
    //Purpose: Struct: To calculate the Z value based on the given formula
    //Restrictions: None
    public struct ZFunction
    {
        public double dX;
        public double dY;
        public double dZ;

        // the constructor for this structure
        public ZFunction(double dX, double dY)
        {
            this.dX = dX;
            this.dY = dY;
            this.dZ = 4 * Math.Pow(dY, 3) + 2 * Math.Pow(dX, 2) - (8 * dX) + 7;
            this.dZ = Math.Round(this.dZ, 3);
        }
    }

    //Author: Shane Doherty / David Schuh
    //Purpose: Program: To create a three dimensional array and store the X, Y and Z values in it based on the given formula
    //Restrictions: None
    class Program
    {
        //Author: Shane Doherty / David Schuh
        //Purpose: Main: Creates a 3D array, loops through each x and y coordinate and stores them, in addition to the z value, in the proper array cells.
        //Restrictions: None
        static void Main(string[] args)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            int nX = 0;
            int nY = 0;

            double[,,] zFunc = new double[41, 21, 3];


            for (x = 0; x <= 4; x += 0.1, ++nX)
            {
                
                x = Math.Round(x, 1);

                
                nY = 0;

                
                for (y = -1; y <= 1; y += 0.1, ++nY)
                {
                    
                    y = Math.Round(y, 1);

                    
                    z = 4 * Math.Pow(y, 3) + 2 * Math.Pow(x, 2) - (8 * x) + 7;

                    
                    z = Math.Round(z, 3);

                    
                    zFunc[nX, nY, 0] = x;
                    zFunc[nX, nY, 1] = y;
                    zFunc[nX, nY, 2] = z;
                }
            }

        }
    }
}
