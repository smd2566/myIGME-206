using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam1_Q12
{
    //Author: Shane Doherty
    //Purpose: Program - Increases the user's salary if their name matches mine (Shane)
    //Restrictions: None
    class Program
    {
        //struct for creating an employee
        struct Employee
        {
            public string sName;
            public double dSalary;

            public Employee(string sName, ref double dSalary)
            {
                this.sName = sName;
                this.dSalary = dSalary;
            }

        }

        //Author: Shane Doherty
        //Purpose: GiveRaise - Increases the salary by $19999.99 if the name matches "shane" and returns true if that is the case, false otherwise
        //Restrictions: None
        static bool GiveRaise(ref Employee employee)
        {
            if (employee.sName.ToLower() == "shane")
            {
                employee.dSalary += 19999.99;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Author: Shane Doherty
        //Purpose: Main - Calls GiveRaise to see if the name matches "shane", and congratulates the user if the function returns true.
        //Displays new salary if that is the case.
        //Restrictions: None

        static void Main(string[] args)
        {

            
            string sName;
            double dSalary = 30000;
            

            Console.WriteLine("Hello! Please enter your name.");
            sName = Console.ReadLine();
            Employee employee = new Employee(sName, ref dSalary);
            if (GiveRaise(ref employee))
            {
                
                Console.WriteLine("Congratulations on your salary increase! Your new salary is $" + employee.dSalary);
            }

        }
    }
}