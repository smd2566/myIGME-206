using System;

namespace Vehicles
{
    //Author: Shane Doherty
    //Purpose: Creates various vehicle objects for future use
    //Restrictions: None

    //creates vehicle object
    public abstract class Vehicle
    {
        public virtual void LoadPassenger() { }

    }

    //creates car object
    public abstract class Car: Vehicle
    {

    }

    //creates train object
    public abstract class Train: Vehicle
    {

    }

    //creates a PassengerCarrier interface
    public interface PassengerCarrier
    {
        public void LoadPassenger() { }
    }

    //creates a HeavyLoadCarrier interface
    public interface HeavyLoadCarrier
    {

    }

    //Creates a Compact object
    public class Compact: Car, PassengerCarrier
    {

    }

    //creates an SUV object
    public class SUV : Car, PassengerCarrier
    {

    }

    //creates a Pickup object
    public class Pickup: Car, HeavyLoadCarrier
    {

    }

    //creates a PassengerTrain object
    public class PassengerTrain: Train, PassengerCarrier
    {

    }

    //creates a FreightTrain object
    public class FreightTrain: Train, HeavyLoadCarrier
    {

    }

    //creates a 424DoubleBogey object
    public class _424DoubleBogey: Train, HeavyLoadCarrier
    {

    }

}
