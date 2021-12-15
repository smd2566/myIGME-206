using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FEQ4
{

    //Author: Shane Doherty
    //Purpose: To serialize and deserialize a singleton class object with certain information
    //Restrictions: An acccess denied error occurs and the information cannot be saved
    class Program
    {
        [Serializable]
        public class Singleton
        {
            private static Singleton _instance = null;

            public string name;
            public int level;
            public int hp;
            public string[] inventory;
            public string liscenseKey;


            private Singleton()
            {
                name = this.name;
                level = this.level;
                hp = this.hp;
                inventory = this.inventory;
                liscenseKey = this.liscenseKey;
            
            }

            public static Singleton GetInstance()
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
                return _instance;
            }



        }


        //Author: Shane Doherty
        //Purpose: Creates an instance of the singleton class, adds values to it, and formats the stream and saves to harddrive
        //Restrictons: An access denied error occurs here
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.GetInstance();

            singleton.name = "Shane";
            singleton.level = 10;
            singleton.hp = 10;
            singleton.inventory = new string[] { "Wood", "Steel" };

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("D:\\PlayerInformation.txt", FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, singleton);

            Singleton newSingleton = (Singleton)formatter.Deserialize(stream);


        }
    }
}
