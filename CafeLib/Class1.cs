using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLib
{
    //Author: Shane Doherty
    //Purpose: Library creation for various hot drinks and business scenarios
    //Restrictions: None

    //initializes a hot drink class
    public abstract class HotDrink
    {
        public bool instant;
        public bool milk;
        private byte sugar;
        public string size;
        public Customer customer;

        public virtual void AddSugar(byte amount)
        {

        }

        public abstract void Steam();

        public HotDrink()
        {

        }

        public HotDrink(string brand)
        {

        }
        
    }

    public interface IMood
    {
        string Mood { get;}
    }

    public interface ITakeOrder
    {
        void TakeOrder();
        
    }
    
    //initializes a waiter
    public class Waiter: IMood
    {
        public string name;
        public string Mood { get; }

        public void ServeCustomer(HotDrink cup)
        {

        }

    }

    //initializes a customer
    public class Customer: IMood
    {
        public string name;
        public string creditCardNumber;

        public string Mood { get; }


    }

    //initializes a cup of coffee
    public class CupOfCoffee: HotDrink, ITakeOrder
    {
        public string beanType;

        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }

        public CupOfCoffee(string brand) : base(brand)
        {

        }

    }

    //initializes a cup of tea
    public class CupOfTea: HotDrink, ITakeOrder
    {
        public string leafType;
        public override void Steam()
        {
            
        }

        public void TakeOrder()
        {

        }

        public CupOfTea(bool customerIsWealthy)
        {

        }
    }

    //initializes a cup of cocoa
    public class CupOfCocoa: HotDrink, ITakeOrder
    {
        public static int numCups;
        public bool marshmallows;
        private string source;

        public string Source { get;  set; }
        public override void Steam()
        {
            
        }

        public override void AddSugar(byte amount)
        {
            
        }

        public void TakeOrder()
        {

        }

        public CupOfCocoa() : this(false)
        {

        }

        public CupOfCocoa(bool marshmallows) : base("Expensive Organic Brand")
        {

        }

    }
}
