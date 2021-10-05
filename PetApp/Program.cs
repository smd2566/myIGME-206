using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetApp
{
    //Author: Shane Doherty / David Schuh
    //Purpose: An application that allows the storage of virtual pets
    //Retrictions: None
    class Program
    {
        //cat interface initialization
        public interface ICat
        {
            void Eat();

            void Play();

            void Scratch();

            void Purr();



        }
        //dog interface initialization
        public interface IDog
        {
            void Eat();

            void Play();

            void Bark();

            void NeedWalk();

            void GoToVet();


        }
        //Pet class initialization with name and age
        public abstract class Pet
        {
            private string name;
            public int age;


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

            public abstract void Eat();
            public abstract void Play();
            public abstract void GoToVet();

            public Pet()
            {

            }

            public Pet(string name, int age)
            {
                this.name = name;
                this.age = age;
            }


        }
        //Dog class initialization with action methods
        public class Dog : Pet, IDog
        {

            public string license;

            public Dog(string szLicense, string szName, int nAge): base(szName, nAge)
            {
                this.license = szLicense;
                
            }

            public override void Eat()
            {
                Console.WriteLine(this.Name + " is eating!");
            }

            public override void Play()
            {
                Console.WriteLine(this.Name + " wants to play!");
            }

            public void Bark()
            {
                Console.WriteLine(this.Name + ":Woof Woof!");
            }
            public void NeedWalk()
            {
                Console.WriteLine(this.Name + " is holding the leash and looking at you!");
            }
            public override void GoToVet()
            {
                Console.WriteLine(this.Name + " should get a checkup, don't you think?");
            }

        }
        //Cat class initialization with action methods
        public class Cat: Pet, ICat
        {
            public Cat()
            {

            }
            public override void Eat()
            {
                Console.WriteLine(this.Name + " is eating!");
            }

            public override void Play()
            {
                Console.WriteLine(this.Name + " wants to play!");
            }

            public void Purr()
            {
                Console.WriteLine(this.Name + ": Purrrr purrrr");
            }

            public void Scratch()
            {
                Console.WriteLine(this.Name + " scratched you! Yowch!");
            }

            public override void GoToVet()
            {
                Console.WriteLine(this.Name + " should get a checkup, don't you think?");
            }

        }

        //Creates the pet list and includes a Count method
        public class Pets
        {
            public List<Pet> petList = new List<Pet>();

            public Pet this[int nPetEl]
            {
                get
                {
                    Pet returnVal;
                    try
                    {
                        returnVal = (Pet)petList[nPetEl];
                    }
                    catch
                    {
                        returnVal = null;
                    }

                    return (returnVal);
                }

                set
                {
                    // if the index is less than the number of list elements
                    if (nPetEl < petList.Count)
                    {
                        // update the existing value at that index
                        petList[nPetEl] = value;
                    }
                    else
                    {
                        // add the value to the list
                        petList.Add(value);
                    }
                }
            }

            public int Count { get; }

            public void Add(Pet pet)
            {
                petList.Add(pet);
            }
            public void Remove(Pet pet)
            {
                petList.Remove(pet);
            }
            public void RemoveAt(int petEl)
            {
                petList.RemoveAt(petEl);
            }



        }

        //Author: Shane Doherty / David Schuh
        //Purpose: Main - Asks the user for pet information and displays a list of actions for a randomly selected pet in the list
        //Restrictions: None
        static void Main(string[] args)
        {
            int result = 0;
            int randomNumber = 0;
            Pet thisPet = null;
            Dog dog = null;
            Cat cat = null;
            IDog iDog = null;
            ICat iCat = null;

            Pets pets = new Pets();
            Random rand = new Random();
            Random newRand = new Random();

            for (int i = 0; i < 50; i++)
            {
                if (rand.Next(1, 11) == 1)
                {
                    if (rand.Next(0, 2) == 0)
                    {
                        
                        Console.WriteLine("You bought a dog!");
                        Console.Write("Dog's Name => ");
                        string dogName = Console.ReadLine();
                        Console.Write("Dog's Age => ");
                        string ageInput = Console.ReadLine();
                        try
                        {
                            result = Int32.Parse(ageInput);
                            
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter an integer");
                        }

                        Console.Write("Dog's License => ");
                        string dogLicense = Console.ReadLine();

                        dog = new Dog(dogLicense, dogName, result);


                        pets.Add(dog);

                    }
                    else
                    {
                        Console.WriteLine("You bought a cat!");
                        Console.Write("Cat's Name => ");
                        string catName = Console.ReadLine();
                        Console.Write("Cat's Age => ");
                        string ageInput = Console.ReadLine();
                        try
                        {
                            result = Int32.Parse(ageInput);
                            
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter an integer");
                        }

                        cat = new Cat();
                        cat.Name = catName;
                        cat.age = result;
                        pets.Add(cat);

                    }
                }
                else
                {
                    // choose a random pet from pets and choose a random activity for the pet to do
                    try
                    {
                        
                        thisPet = pets.petList[newRand.Next(0, pets.Count)];
                    }
                    catch
                    {
                        continue;
                    }
                    


                    if (thisPet is Dog)
                    {
                        iDog = (Dog)thisPet;
                        randomNumber = rand.Next(0, 5);
                        if (randomNumber == 0)
                        {
                            iDog.Eat();
                        }
                        if (randomNumber == 1)
                        {
                            iDog.Play();
                        }
                        if (randomNumber == 2)
                        {
                            iDog.Bark();
                        }
                        if (randomNumber == 3)
                        {
                            iDog.NeedWalk();
                        }
                        if (randomNumber == 4)
                        {
                            iDog.GoToVet();
                        }

                        thisPet = null;
                        iDog = null;


                    }

                    if (thisPet is Cat)
                    {
                        iCat = (Cat)thisPet;
                        randomNumber = rand.Next(0, 4);
                        if (randomNumber == 0)
                        {
                            iCat.Eat();
                        }
                        if (randomNumber == 1)
                        {
                            iCat.Play();
                        }
                        if (randomNumber == 2)
                        {
                            iCat.Purr();
                        }
                        if (randomNumber == 3)
                        {
                            iCat.Scratch();
                        }
                        //if (randomNumber == 4)
                        //{
                        //    iCat.GoToVet();
                        //}
                        //The cat cannot go to the vet according to the lab writeup and the Slack channel

                        thisPet = null;
                        iCat = null;
                    }


                    
                }


            }



        }
    }
}
