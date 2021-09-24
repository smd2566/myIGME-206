using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            //Causes a compile time error later: Should be initialized as it is a string
            //string sNumber;
            string sNumber = null;
            int nX;
            //Complile time error: missing semicolon
            //int nY
            int nY;
            int nAnswer;

            //Compile time error: Missing double quotes 
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("This program calculates x ^ y");


            do
            {
                Console.Write("Enter a whole number for x: ");
                //Logical error: The Console.ReadLine() is not set equal to anything
                //Console.ReadLine();
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();

                //Logical Error: Should be out nY, not nX. Also needs a !
                //} while (int.Parse(sNumber, out nX));
            } while (!int.TryParse(sNumber, out nY));

            // compute the factorial of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Logical error. The values are not actually written, just the literal text. Needs to be reformatted.
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine("{0}^{1} = {2}", nX, nY, nAnswer);
        }


        //Compile time error: Method should be static so calls to the method can be compiled
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //Logical Error: Should return 1, not 0
                //returnVal = 0;
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //Run-time error: Causes a stack overflow. Should be nExponent - 1, not + 1
                //nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //Compile Time Error: should be return returnVal
            //returnVal;
            return returnVal;
        }
    }
}