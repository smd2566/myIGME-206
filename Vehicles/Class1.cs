using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public virtual void LoadPassenger() { }

    }

    public abstract class Car: Vehicle
    {

    }

    public abstract class Train: Vehicle
    {

    }

    public interface PassengerCarrier
    {
        public void LoadPassenger() { }
    }

    public interface HeavyLoadCarrier
    {

    }

    public class Compact: Car, PassengerCarrier
    {

    }

    public class SUV : Car, PassengerCarrier
    {

    }

    public class Pickup: Car, HeavyLoadCarrier
    {

    }

    public class PassengerTrain: Train, PassengerCarrier
    {

    }

    public class FreightTrain: Train, HeavyLoadCarrier
    {

    }

    public class _424DoubleBogey: Train, HeavyLoadCarrier
    {

    }

}
