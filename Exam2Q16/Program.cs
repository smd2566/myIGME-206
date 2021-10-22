using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q16
{
    //Author: Shane Doherty
    //Purpose: To create a shallow copy of an object
    //Restrictions: None
    class Program
    {

        //performs the shallow copy
        public class MyClass
        {
            public object ShallowCopy()
            {
                return this.MemberwiseClone();
            }
        }


        //Author: Shane Doherty
        //Purpose: Main: Changes objectB into a shallow copy of objectA
        //Restrictions: None
        static void Main(string[] args)
        {
            MyClass objectA = new MyClass();
            MyClass objectB = (MyClass)objectA.ShallowCopy();

        }
    }
}
