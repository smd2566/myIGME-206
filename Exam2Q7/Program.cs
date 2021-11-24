using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q7
{
    //Author: Shane Doherty
    //Purpose: Program - To create a list of wizards and sort them by age
    //Restrictions: None
    class Program
    {
        public class Wizard : IComparable<Wizard>
        {
            public string name;
            public int age;
            public Wizard(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public int CompareTo(Wizard n)
            {
                return this.age.CompareTo(n.age);
            }
        }
        //Author: Shane Doherty
        //Purpose: Main - Uses a delegate expression to set up the sort method and prints out the results of the sorted wizard list
        //Restrictions: None
        static void Main(string[] args)
        {
            List<Wizard> wizardList = new List<Wizard>();

            Wizard wizard1 = new Wizard("Bob", 23);
            Wizard wizard2 = new Wizard("Ash", 55);
            Wizard wizard3 = new Wizard("Rob", 18);
            Wizard wizard4 = new Wizard("Macy", 33);
            Wizard wizard5 = new Wizard("Todd", 90);
            Wizard wizard6 = new Wizard("Matt", 17);
            Wizard wizard7 = new Wizard("Lewis", 76);
            Wizard wizard8 = new Wizard("Stan", 39);
            Wizard wizard9 = new Wizard("Selena", 25);
            Wizard wizard10 = new Wizard("Marge", 61);

            wizardList.Add(wizard1);
            wizardList.Add(wizard2);
            wizardList.Add(wizard3);
            wizardList.Add(wizard4);
            wizardList.Add(wizard5);
            wizardList.Add(wizard6);
            wizardList.Add(wizard7);
            wizardList.Add(wizard8);
            wizardList.Add(wizard9);
            wizardList.Add(wizard10);

            wizardList.Sort();

            wizardList = wizardList.OrderBy(delegate (Wizard n) { return n.age; }).ToList();
            

            foreach (Wizard wizard in wizardList)
            {
                Console.WriteLine(wizard.age);
            }







        }
    }
}
