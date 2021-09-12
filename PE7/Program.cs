using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

namespace Madlibs
{
    class Program
    {
        static void Main(string[] args)
        {
            int numLibs = 0;
            int cntr = 0;
            int nChoice = 0;

            StreamReader input;

            // open the template file to count how many Mad Libs it contains
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            string line = null;
            while ((line = input.ReadLine()) != null)
            {
                ++numLibs;
            }

            // close it
            input.Close();

            // only allocate as many strings as there are Mad Libs
            string[] madLibs = new string[numLibs];

            // read the Mad Libs into the array of strings
            input = new StreamReader("c:\\templates\\MadLibsTemplate.txt");

            line = null;
            while ((line = input.ReadLine()) != null)
            {
                // set this array element to the current line of the template file
                madLibs[cntr] = line;

                // replace the "\\n" tag with the newline escape character
                madLibs[cntr] = madLibs[cntr].Replace("\\n", "\n");

                ++cntr;
            }

            input.Close();

            // prompt the user for which Mad Lib they want to play (nChoice)
            for (int h = 0; h < 1; h++)
            {
                Console.WriteLine("Would you like to play Mad Libs? Please enter either yes or no");
                string sFirstUserInput = Console.ReadLine();
                if (sFirstUserInput.ToLower() == "yes")
                {
                    h = 100;
                }
                if (sFirstUserInput.ToLower() == "no")
                {
                    Console.WriteLine("Goodbye");
                    Environment.Exit(-1);
                }
                if (sFirstUserInput.ToLower() != "yes" && sFirstUserInput.ToLower()!= "no")
                {
                    Console.WriteLine("Please enter either yes or no");
                    h--;
                }

            }
            

            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Please enter the Mad Lib that you would like to play. [1 to " + (cntr - 1) + "]");
                string userChoice = Console.ReadLine();
                try
                {
                    nChoice = Convert.ToInt32(userChoice);
                }
                catch
                {

                    Console.WriteLine("Incorrect format: Only enter a NUMBER");
                    --i;



                }
            }

                // split the Mad Lib into separate words
                string[] words = madLibs[nChoice].Split(' ');

            string sFullStory = null;
            foreach (string word in words)
            {
                // if word is a placeholder
                // prompt the user for the replacement
                // and append the user response to the result string
                // else append word to the result string

                
                string sUserReplacement = null;
                string sAskString = null;
                string sCopyString = null;
                bool bValid = true;
                //Console.WriteLine(word);

                if (word[0] == '{')
                {
                    sCopyString = word;
                    foreach (char c in word)
                    {
                        if (c != '{' && c != '}')
                        {
                            //Console.Write(c);
                            sAskString += c;
                        }
                        
                    }
                    foreach (char z in sAskString)
                    {
                        sAskString = sAskString.Replace('_', ' ');
                        sAskString = sAskString.Replace(',', ' ');
                        sAskString = sAskString.Replace('.', ' ');
                    }
                    Console.WriteLine("Please enter a(n) " + sAskString);
                    string userInput = Console.ReadLine();
                    sFullStory += (userInput + " ");


                } else
                {
                    sFullStory += (word + " ");
                }

            }
            Console.Write(sFullStory);
            Console.WriteLine(" ");
        }
    }
}
