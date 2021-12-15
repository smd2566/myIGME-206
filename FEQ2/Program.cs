using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Threading;
namespace FEQ2
{

    class Trivia
    {
        public int response_code;
        public List<TriviaResult> results;
    }

    class TriviaResult
    {
        public string category;
        public string type;
        public string difficulty;
        public string question;
        public string correct_answer;
        public List<string> incorrect_answers;
    }


    //Author: Shane Doherty
    //Purpose: Program - A labrynth game where states of the rooms change every second, with the goal to escape.
    //Resctrictions: The rooms alternate from gas->liquid->ice->gas, not gas->liquid->ice->liquid->gas (Sorry I could not figure this out)
    class Program
    {
        //Question 2:
        //---------------------------------------------------------------------------------------

        static int[,] mCGraph = new int[,]
        {
            //        0        1           2         3           4           5            6             7

            //        A        B           D         C           E           G            F             H

            /*A*/{   -1,       1,         -1,       5,          -1,          -1,          -1,           -1  },


            /*B*/{  -1,       -1,         1,       -1,         -1,         -1,            7,           -1},


            /*D*/{   -1,        1,        -1,      0,          -1,         -1,           -1,           -1 },


            /*C*/{  -1,       -1,         0,       -1,          2,          -1,           -1,           -1 },


            /*E*/{ -1,      -1,        -1,         2,         -1,          2,            -1,          -1 },


            /*G*/{ -1,      -1,        -1,         -1,         2,         -1,             1,          -1 },


            /*F*/{ -1,       -1,        -1,        -1,         -1,         -1,            -1,         4},


            /*H*/{   -1,      -1,        -1,       -1,         -1,         -1,            -1,        -1 }
        };

        //List graph
        //(index of neighbor, cost)
        static (int, int)[][] firstListGraph = new (int, int)[][]
        {
            /* listGraph[0] A*/ new (int, int)[] {(1, 1), (3, 5)},
            /* listGraph[1] B*/ new (int, int)[] {(2, 1), (6, 7)},
            /* listGraph[2] D*/ new (int, int)[] {(1, 1), (3, 0)},
            /* listGraph[3] C*/ new (int, int)[] {(2, 0), (4, 2)},
            /* listGraph[4] E*/ new (int, int)[] {(3, 2), (5, 2)},
            /* listGraph[5] G*/ new (int, int)[] {(4, 2), (6,  1)},
            /* listGraph[6] F*/ new (int, int)[] {(7,  4)},
            /* listGraph[7] H*/ null
        };

        //--------------------------------------------------------------------------------------------------------------




        static Random rand = new Random();
        static System.Timers.Timer timer;
        static bool bTimedOut;
        static int secondsTaken;

        static string[] roomStates = new string[]
        {
                "Gas",
                "Liquid",
                "Ice",
        };


        //List graph
        //(index of neighbor, state, cost)
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            /* listGraph[0] A*/ new (int, string, int)[] {(1, roomStates[1], 1), (3, roomStates[0], 5)},
            /* listGraph[1] B*/ new (int, string, int)[] {(2, roomStates[2], 1), (6, roomStates[0], 7)},
            /* listGraph[2] D*/ new (int, string, int)[] {(1, roomStates[1], 1), (3, roomStates[0], 0)},
            /* listGraph[3] C*/ new (int, string, int)[] {(2, roomStates[2], 0), (4, roomStates[1], 2)},
            /* listGraph[4] E*/ new (int, string, int)[] {(3, roomStates[0], 2), (5, roomStates[2], 2)},
            /* listGraph[5] G*/ new (int, string, int)[] {(4, roomStates[1], 2), (6, roomStates[0],  1)},
            /* listGraph[6] F*/ new (int, string, int)[] {(7, roomStates[1], 4)},
            /* listGraph[7] H*/ null
        };



        private static void ExecuteInForeground()
        {
            int nRoom = 0;
            int i = 0;
            var sw = Stopwatch.StartNew();
            
            do
            {

                while (nRoom != 7)
                {

                    (int, string, int)[] thisRoomsNeighbors = listGraph[nRoom];
                    (int, string, int) neighborCopy = thisRoomsNeighbors[0];

                    foreach ((int, string, int) neighbor in thisRoomsNeighbors)
                    {
                        neighborCopy = neighbor;
                        
                        if (neighbor.Item2 == roomStates[0])
                        {
                            neighborCopy.Item2 = roomStates[1];
                        }

                        else if (neighbor.Item2 == roomStates[1])
                        {
                            neighborCopy.Item2 = roomStates[2];
                        }

                        else if (neighbor.Item2 == roomStates[2])
                        {
                            neighborCopy.Item2 = roomStates[0];
                        }

                        
                        thisRoomsNeighbors[i] = neighborCopy;
                        listGraph[nRoom] = thisRoomsNeighbors;
                        i++;
                        
                    }
                    i = 0;
                    nRoom++;   
                }
                nRoom = 0;

               secondsTaken++;
               Thread.Sleep(1000);
            } while (true);
            sw.Stop();
        }


        //Author: Shane Doherty / David Schuh (Trivia API)
        //Purpose: Allows the mechanics to function, asks the user if they want to progress, change state or wager HP in trivia.
        //The game ends when the player's HP = 0 or the player makes it to room H. The time taken and number of turns is recorded
        //Restrictions: None
        static void Main(string[] args)
        {
            var th = new Thread(ExecuteInForeground);
            th.Start();
            //Thread.Sleep(1000);


            int nRoom = 0;

            int turnsTaken = 0;

            int playerHp = 5;

            int roomChosen = 0;

            string userResponse = null;

            string userState = roomStates[0];

            string[] roomIndexes = new string[]
            {
                "A",
                "B",
                "D",
                "C",
                "E",
                "G",
                "F",
                "H"
            };

            Console.WriteLine("Each room has one of three states: Gas, Liquid and Ice");
            Console.WriteLine("The rooms change states every second, from gas->liquid->ice->liquid->gas and so on");
            Console.WriteLine("Each room is initialized as follows: ");
            Console.WriteLine("Room A: Ice");
            Console.WriteLine("Room B: Liquid");
            Console.WriteLine("Room C: Gas");
            Console.WriteLine("Room D: Ice");
            Console.WriteLine("Room E: Liquid");
            Console.WriteLine("Room F: Gas");
            Console.WriteLine("Room G: Ice");
            Console.WriteLine("Room H: Liquid");

            while (nRoom != 7 && playerHp != 0)
            {
                (int, string, int)[] thisRoomsNeighbors = listGraph[nRoom];
                

                foreach ((int, string, int) neigh in thisRoomsNeighbors)
                {
                    //Console.WriteLine(neigh);
                    // if the player's HP is greater than the cost of the exit
                    if (playerHp > neigh.Item3)
                    {
                        //display the exit
                        Console.WriteLine("There is an exit labeled " + roomIndexes[neigh.Item1] + " which costs " + neigh.Item3 + " HP");

                    }
                }

                Console.WriteLine("Your current state is: " + userState);
                Console.WriteLine("Your current HP is: " + playerHp);
                Console.WriteLine("Do you want to leave the room, wager for more HP, or change state (cost: 1 HP)? (Type 'l' for leave, 'w' for wager, 'c' for state change)");
                userResponse = Console.ReadLine().ToLower()[0].ToString();
                if (userResponse == "l")
                {
                    turnsTaken++;
                    Console.WriteLine("Enter the letter of the room you want to go into");
                    userResponse = Console.ReadLine().ToLower()[0].ToString();
                    for (int i = 0; i < roomIndexes.Length; i++)
                    {
                        if (userResponse == roomIndexes[i].ToLower())
                        {
                            roomChosen = i;
                        }
                    }

                    foreach ((int, string, int) neigh in thisRoomsNeighbors)
                    {
                        Console.WriteLine(neigh.Item2);
                        if (neigh.Item1 == roomChosen && userState == neigh.Item2)
                        {
                            nRoom = roomChosen;
                        }
                    }

              
                    

                    Console.WriteLine("HP: " + playerHp);



                } else if (userResponse == "c")
                {
                    turnsTaken++;
                    playerHp--;
                    if (userState == roomStates[0])
                    {
                        userState = roomStates[1];
                    }

                    else if (userState == roomStates[1])
                    {
                        userState = roomStates[2];
                    }

                    else if (userState == roomStates[2])
                    {
                        userState = roomStates[0];
                    }
                    Console.WriteLine("Your state is now: " + userState);
                }
               
                
                else
                {
                    turnsTaken++;
                    // otherwise grinding for HP

                    // trivia question
                    // fetch api
                    // 15 second limit to answer
                    // multiple choice 1-4

                    // ask player how much HP to wager (limited to playerHp)

                    string url = null;
                    string s = null;

                    HttpWebRequest request;
                    HttpWebResponse response;
                    StreamReader reader;

                    url = "https://opentdb.com/api.php?amount=1&type=multiple";

                    request = (HttpWebRequest)WebRequest.Create(url);
                    response = (HttpWebResponse)request.GetResponse();
                    reader = new StreamReader(response.GetResponseStream());
                    s = reader.ReadToEnd();
                    reader.Close();

                    Trivia trivia = JsonConvert.DeserializeObject<Trivia>(s);

                    trivia.results[0].question = HttpUtility.HtmlDecode(trivia.results[0].question);
                    trivia.results[0].correct_answer = HttpUtility.HtmlDecode(trivia.results[0].correct_answer);
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count; ++i)
                    {
                        trivia.results[0].incorrect_answers[i] = HttpUtility.HtmlDecode(trivia.results[0].incorrect_answers[i]);
                    }

                    // prompt for wager amount
                    string sWager = null;
                    int nWager = 0;

                    do
                    {
                        Console.Write("Enter how much of your HP to wager: ");
                        sWager = Console.ReadLine();
                    } while (!int.TryParse(sWager, out nWager) || (nWager < 0) || (nWager > playerHp));

                    // ask question
                    Console.WriteLine(trivia.results[0].question);

                    // choose random answer spot
                    int nAnswer = rand.Next(trivia.results[0].incorrect_answers.Count + 1);
                    int nWrongCntr = 0;

                    // output the correct answer in random position
                    // prefix each with 1-N to allow player to answer with N
                    for (int i = 0; i < trivia.results[0].incorrect_answers.Count + 1; ++i)
                    {
                        if (i == nAnswer)
                        {
                            // if this is the correct answer to show
                            Console.WriteLine($"{i + 1}: {trivia.results[0].correct_answer}");
                        }
                        else
                        {
                            // show the incorrect answers
                            Console.WriteLine($"{i + 1}: {trivia.results[0].incorrect_answers[nWrongCntr]}");
                            ++nWrongCntr;
                        }
                    }

                    // increment the answer to be 1-based instead of 0-based
                    ++nAnswer;

                    // 15 second timer
                    timer = new System.Timers.Timer(15000);

                    // use an anonymous method via a lambda expression to catch the lapsed timer event
                    timer.Elapsed += (o, e) => { bTimedOut = true; timer.Stop(); Console.WriteLine("Time's up. Press enter."); };

                    timer.Start();

                    Console.Write("==> ");
                    string sAnswer = Console.ReadLine();

                    timer.Stop();

                    sAnswer = nAnswer.ToString();

                    // if an incorrect answer
                    if (sAnswer != nAnswer.ToString() || bTimedOut)
                    {
                        Console.WriteLine($"Wrong!  The answer was {nAnswer}.");
                        playerHp -= nWager;
                    }
                    else
                    {
                        Console.WriteLine("Correct! You are stronger!");
                        playerHp += nWager;
                    }

                }

                
            }
            if (nRoom == 7)
            {
                Console.WriteLine("Congratulations! You won!");
                Console.WriteLine("Turns taken: " + turnsTaken);
                Console.WriteLine("Time taken (in seconds): " + secondsTaken);
            }
            if (playerHp == 0)
            {
                Console.WriteLine("You died!");
                Console.WriteLine("Turns taken: " + turnsTaken);
                Console.WriteLine("Time taken (in seconds): " + secondsTaken);
            }




        }
    }
}
