using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2Q10
{
    //Author: Shane Doherty
    //Purpose: Program - A virtual weightlifting experience using classes and interfaces
    //Restrictions: None
    class Program
    {
        //initializes a bench interface
        public interface BenchInterface
        {
            void RackItem();
            void SwitchSafety();
            void Breath();
            void Press();

        }

        //initializes a weight interface
        public interface WeightInterface
        {
            void Curl();
            void ChangeWeights();
            void AddWeights();
            void RemoveWeights();

        }

        //creation of equipment abstract class
        public abstract class Equipment
        {
            public bool occupied;
            public string color;

            public string Color
            {
                get
                {
                    return color;
                }

                set
                {
                    color = value;
                }
            }

            public virtual void BeginWorkout()
            {

            }

            public abstract void EndWorkout();
            
        }

        //creates a bench press object
        public class BenchPress: Equipment, BenchInterface
        {
            public void RackItem()
            {
                Console.WriteLine("I am putting away the barbell");
            }
            public void SwitchSafety()
            {
                Console.WriteLine("I will turn on the bench safety");
            }
            public void Breath()
            {
                Console.WriteLine("Breath in, breath out");

            }
            public void Press()
            {
                Console.WriteLine("AHHHH");
            }
            public override void BeginWorkout()
            {
                Console.WriteLine("Setting up the bench");
            }
            public override void EndWorkout()
            {
                Console.WriteLine("Cleaning the bench");
            }

        }

        //creates a dumbbell curls object
        public class DumbbellCurls: Equipment, WeightInterface
        {
            public void Curl()
            {
                Console.WriteLine("UMPHH");
            }
            public void ChangeWeights()
            {
                Console.WriteLine("Maybe I should use plates instead");
            }
            public void AddWeights()
            {
                Console.WriteLine("This is too light for me!");
            }
            public void RemoveWeights()
            {
                Console.WriteLine("Ouch this is too heavy!");
            }
            public override void BeginWorkout()
            {
                Console.WriteLine("Gripping the dumbbells");
            }
            public override void EndWorkout()
            {
                Console.WriteLine("Wiping down the handles");
            }
        }

        //calls the respective methods based on passed in object type
        static void MyMethod(object obj)
        {
            BenchInterface benchInterface = null;
            WeightInterface weightInterface = null;
            Equipment equipment = null;
            
            if (obj is BenchInterface)
            {
                benchInterface = (BenchInterface)obj;

                benchInterface.RackItem();
                benchInterface.SwitchSafety();
                benchInterface.Breath();
                benchInterface.Press();
                if (obj is Equipment)
                {
                    equipment = (Equipment)obj;
                    equipment.BeginWorkout();
                    equipment.EndWorkout();
                }
            } else if (obj is WeightInterface)
            {
                weightInterface = (WeightInterface)obj;

                weightInterface.Curl();
                weightInterface.ChangeWeights();
                weightInterface.AddWeights();
                weightInterface.RemoveWeights();
                if (obj is Equipment)
                {
                    equipment = (Equipment)obj;
                    equipment.BeginWorkout();
                    equipment.EndWorkout();
                }

            }

        }

        //Author: Shane Doherty
        //Purpose: Main - Calls MyMethod to call additional methods on the created objects
        //Restrictions: None
        static void Main(string[] args)
        {
            BenchPress benchPress = new BenchPress();
            DumbbellCurls dumbbellCurls = new DumbbellCurls();

            MyMethod(benchPress);
            MyMethod(dumbbellCurls);

        }
    }
}
