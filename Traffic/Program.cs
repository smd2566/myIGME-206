using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;


namespace Traffic
{
    //Author: Shane Doherty
    //Purpose: Displays the type of vehicle that was passed into AddPassenger
    //Restrictions: None
    class Program
    {
        //Adds a passenger
        static public void AddPassenger(object obj)
        {
            if (obj is PassengerCarrier)
            {
                PassengerCarrier passengerCarrier;
                passengerCarrier = (PassengerCarrier)obj;

                passengerCarrier.LoadPassenger();
                Console.WriteLine(passengerCarrier.ToString());
            }
            
        }
        //Author: Shane Doherty
        //Purpose: Main - Calls AddPassenger and creates a PassengerCarrier vehicle object
        static void Main(string[] args)
        {
            SUV Subaru = new SUV();
            AddPassenger(Subaru);
        }
    }
}
