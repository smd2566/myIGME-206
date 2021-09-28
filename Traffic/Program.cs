using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewVehicles;

namespace Traffic
{
    class Program
    {
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
        static void Main(string[] args)
        {
            SUV Subaru = new SUV();
            AddPassenger(Subaru);
        }
    }
}
