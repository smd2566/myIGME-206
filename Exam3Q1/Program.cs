using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam3Q1
{
    //Author Shane Doherty
    //Purpose: To reverse a user entered string, also to test if its a palindrome and tells how many of each letter are in the user entered string
    //Restrictions: None
    class Program
    {
        //Author Shane Doherty
        //Purpose: Main: Asks the user for a string and then reverses it and displays it back to the user. Checks for palindrom and number of each alphabetical letter
        //Restrictions: None

        static void Main(string[] args)
        {
            int numA = 0;
            int numB = 0;
            int numC = 0;
            int numD = 0;
            int numE = 0;
            int numF = 0;
            int numG = 0;
            int numH = 0;
            int numI = 0;
            int numJ = 0;
            int numK = 0;
            int numL = 0;
            int numM = 0;
            int numN = 0;
            int numO = 0;
            int numP = 0;
            int numQ = 0;
            int numR = 0;
            int numS = 0;
            int numT = 0;
            int numU = 0;
            int numV = 0;
            int numW = 0;
            int numX = 0;
            int numY = 0;
            int numZ = 0;

            string characters = null;
            string reversedCharacters = null;

            string sUserInput = null;
            string sReturnString = null;

            //bool isPalindrome = false;
            Console.WriteLine("Please enter a string");
            sUserInput = Console.ReadLine();

            foreach (char c in sUserInput)
            {
                if (c.Equals('A') || c.Equals('a'))
                {
                    numA++;
                    characters = characters + c;
                }
                if (c.Equals('B') || c.Equals('b'))
                {
                    numB++;
                    characters = characters + c;
                }
                if (c.Equals('C') || c.Equals('c'))
                {
                    numC++;
                    characters = characters + c;
                }
                if (c.Equals('D') || c.Equals('d'))
                {
                    numD++;
                    characters = characters + c;
                }
                if (c.Equals('E') || c.Equals('e'))
                {
                    numE++;
                    characters = characters + c;
                }
                if (c.Equals('F') || c.Equals('f'))
                {
                    numF++;
                    characters = characters + c;
                }
                if (c.Equals('G') || c.Equals('g'))
                {
                    numG++;
                    characters = characters + c;
                }
                if (c.Equals('H') || c.Equals('h'))
                {
                    numH++;
                    characters = characters + c;
                }
                if (c.Equals('I') || c.Equals('i'))
                {
                    numI++;
                    characters = characters + c;
                }
                if (c.Equals('J') || c.Equals('j'))
                {
                    numJ++;
                    characters = characters + c;
                }
                if (c.Equals('K') || c.Equals('k'))
                {
                    numK++;
                    characters = characters + c;
                }
                if (c.Equals('L') || c.Equals('l'))
                {
                    numL++;
                    characters = characters + c;
                }
                if (c.Equals('M') || c.Equals('m'))
                {
                    numM++;
                    characters = characters + c;
                }
                if (c.Equals('N') || c.Equals('n'))
                {
                    numN++;
                    characters = characters + c;
                }
                if (c.Equals('O') || c.Equals('o'))
                {
                    numO++;
                    characters = characters + c;
                }
                if (c.Equals('P') || c.Equals('p'))
                {
                    numP++;
                    characters = characters + c;
                }
                if (c.Equals('Q') || c.Equals('q'))
                {
                    numQ++;
                }
                if (c.Equals('R') || c.Equals('r'))
                {
                    numR++;
                    characters = characters + c;
                }
                if (c.Equals('S') || c.Equals('s'))
                {
                    numS++;
                    characters = characters + c;
                }
                if (c.Equals('T') || c.Equals('t'))
                {
                    numT++;
                    characters = characters + c;
                }
                if (c.Equals('U') || c.Equals('u'))
                {
                    numU++;
                    characters = characters + c;
                }
                if (c.Equals('V') || c.Equals('v'))
                {
                    numV++;
                    characters = characters + c;
                }
                if (c.Equals('W') || c.Equals('w'))
                {
                    numW++;
                    characters = characters + c;
                }
                if (c.Equals('X') || c.Equals('x'))
                {
                    numX++;
                    characters = characters + c;
                }
                if (c.Equals('Y') || c.Equals('y'))
                {
                    numY++;
                    characters = characters + c;
                }
                if (c.Equals('Z') || c.Equals('z'))
                {
                    numZ++;
                    characters = characters + c;
                }
            }



            //for (int i = sUserInput.Length; i > 0; i--)
            //{
            //    sReturnString += sUserInput[i - 1];
            //}

            //for (int i = characters.Length; i > 0; i--)
            //{
            //    reversedCharacters += characters[i - 1];
            //}

            
            //if (characters.ToLower() == reversedCharacters.ToLower())
            //{
                //isPalindrome = true;
            //}


            Console.WriteLine("Number of A/a: " + numA);
            Console.WriteLine("Number of B/b: " + numB);
            Console.WriteLine("Number of C/c: " + numC);
            Console.WriteLine("Number of D/d: " + numD);
            Console.WriteLine("Number of E/e: " + numE);
            Console.WriteLine("Number of F/f: " + numF);
            Console.WriteLine("Number of G/g: " + numG);
            Console.WriteLine("Number of H/h: " + numH);
            Console.WriteLine("Number of I/i: " + numI);
            Console.WriteLine("Number of J/j: " + numJ);
            Console.WriteLine("Number of K/k: " + numK);
            Console.WriteLine("Number of L/l: " + numL);
            Console.WriteLine("Number of M/m: " + numM);
            Console.WriteLine("Number of N/n: " + numN);
            Console.WriteLine("Number of O/o: " + numO);
            Console.WriteLine("Number of P/p: " + numP);
            Console.WriteLine("Number of Q/q: " + numQ);
            Console.WriteLine("Number of R/r: " + numR);
            Console.WriteLine("Number of S/s: " + numS);
            Console.WriteLine("Number of T/t: " + numT);
            Console.WriteLine("Number of U/u: " + numU);
            Console.WriteLine("Number of V/v: " + numV);
            Console.WriteLine("Number of W/w: " + numW);
            Console.WriteLine("Number of X/x: " + numX);
            Console.WriteLine("Number of Y/y: " + numY);
            Console.WriteLine("Number of Z/z: " + numZ);
            Console.WriteLine("--------------");
            //Console.WriteLine("Reversed string: ");
            //Console.WriteLine(sReturnString);
            //Console.WriteLine("--------------");
            //Console.WriteLine("Is palindrome: " + isPalindrome);





        }
    }
}