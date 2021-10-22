using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q15
{
    //Author: Shane Doherty
    //Purpose: To represent birthdays from a sorted list in console
    //Restrictions: None
    class Program
    {
        
        //creates a sorted list of randomly generated birthdays
        static SortedList<string, DateTime> AddObjects(SortedList<string, DateTime> sortedList)
        {
            
            string name = null;
            DateTime date = new DateTime(2000, 1, 1);
            int randomMonth = 0;
            int randomDay = 0;
            int randomYear = 0;
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                randomMonth = random.Next(1, 10);
                randomDay = random.Next(1, 20);
                randomYear = random.Next(1990, 2021);
                date = new DateTime(randomYear, randomMonth, randomDay);
                name = "Friend " + (i + 1).ToString();
                sortedList.Add(name, date);
            }

            return sortedList;
        }

        //Author: Shane Doherty
        //Purpose: Calls AddObjects() to add birthdays to the list and prints them in console accordingly
        //Restrictions: None
        static void Main(string[] args)
        {
            SortedList<string, DateTime> friendBirthdays = new SortedList<string, DateTime>();
            friendBirthdays = AddObjects(friendBirthdays);

            foreach (KeyValuePair<string, DateTime> kvp in friendBirthdays)
            {
                Console.WriteLine(kvp.Value);
                Console.WriteLine(kvp.Key);
            }

        }
    }
}
