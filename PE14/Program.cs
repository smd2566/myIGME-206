using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE14
{
    //Author: Shane Doherty
    //Purpose: Program - Creates two types of monsters and both can speak
    //Restrictions: None
    class Program
    {

        //initializes a monster
        public abstract class Monster
        {
            private string name;

            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;
                }
            }
        }

        //monster interface initialization
        public interface IMonster
        {
            void Speak();
        }

        //creates a dragon
        public class Dragon: Monster, IMonster
        {
            public void Speak()
            {
                Console.WriteLine("Roar!!");
            }
        }


        //creates a werewolf
        public class Werewolf: Monster, IMonster
        {
            public void Speak()
            {
                Console.WriteLine("Awoo!!");
            }
        }

        //calls speak on the monster that is passed in
        public static void MyMethod(object myObject)
        {
            IMonster iMonster = null;

            if (myObject is IMonster)
            {
                iMonster = (IMonster)myObject;
                iMonster.Speak();
            }
        }


        //Author: Shane Doherty
        //Purpose: Main - Calls the MyMethod on both monsters so they can speak in console
        //Resctrictions: None
        static void Main(string[] args)
        {
            Dragon dragon = new Dragon();
            Werewolf werewolf = new Werewolf();

            MyMethod(dragon);
            MyMethod(werewolf);
        }
    }
}
