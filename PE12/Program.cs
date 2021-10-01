using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE12
{
    //Author: Shane Doherty
    //Purpoose: Program - Returns the private string from the base class and appends a new phrase
    //Restrictions: None
    class Program
    {
        public class MyClass
        {
            private string myString = "Hello";
            private string MyString
            {
                set
                {
                    
                }
            }

            //returns myString
            public virtual string GetString()
            {
                return myString;
            }
        }

        //Returns the string to the user and appends (output derived from the base class)
        public class MyDerivedClass: MyClass
        {
            //overrides base GetString method
            public override string GetString()
            {
                return base.GetString() + " (output derived from the base class)";
            }
        }




        //Author: Shane Doherty
        //Purpoose: Main - Creates an instance of the derived class and calls GetString() through that instance
        //Restrictions: None
        static void Main(string[] args)
        {
           
            MyDerivedClass myDerivedClass = new MyDerivedClass();
            Console.WriteLine(myDerivedClass.GetString());

        }
    }
}
