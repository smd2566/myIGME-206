using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q17
{
    //Author: Shane Doherty / David Schuh
    //Purpose: Prints out dialogue for newly created friend objects via a class
    //Restrictions: None
    static class Program
    {

        //instantiates a friend object
        public class Friend
        {
            public string name;
            public string greeting;
            public DateTime birthdate;
            public string address;
        }



        //Author: Shane Doherty / David Schuh
        //Purpose: Main- Sets dialogue and prints it to console
        //Restrictions: None
        static void Main(string[] args)
        {
            Friend friend = new Friend();
            Friend enemy = new Friend();


            friend.name = "Charlie Sheen";
            friend.greeting = "Dear Charlie";
            friend.birthdate = DateTime.Parse("1967-12-25");
            friend.address = "123 Any Street, NY NY 12202";

            // now he has become my enemy
            //enemy = friend;

            // set the enemy greeting and address without changing the friend variable
            enemy.greeting = "Sorry Charlie";
            enemy.address = "Return to sender.  Address unknown.";

            Console.WriteLine($"friend.greeting => enemy.greeting: {friend.greeting} => {enemy.greeting}");
            Console.WriteLine($"friend.address => enemy.address: {friend.address} => {enemy.address}");


        }
    }
}
