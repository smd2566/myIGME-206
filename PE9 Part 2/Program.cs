using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE9_Part_2
{
    //Author: Shane Doherty
    //Purpose: To initiate ReadLine() from a delegate method
    //Restrictions: None
    class Program
    {
        //Author: Shane Doherty
        //Purpose: Encapsulates the method
        //Restrictions: None
        public delegate void Del();

        //Author: Shane Doherty
        //Purpose: Mimics ReadLine()
        //Restrictions: None
        public static void DelegateMethod()
        {
            Console.ReadLine();
        }

        //Author: Shane Doherty
        //Purpose: Main - Calls the delegate method
        //Restrictions: None
        static void Main(string[] args)
        {
            Del handler = DelegateMethod;
            handler();





        }
    }
}
