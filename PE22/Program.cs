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



namespace Dont_Die_Part_1
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
    //Purpose: A text based adventure game that asks questions inbetween that requires HP
    //Restrictions: The program crashes after the second room, the timer is not implemented (I really tried)
    class Program
    {
        static bool bTimeOut = false;
        static Timer timeOutTimer;
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            Console.WriteLine();
            Console.WriteLine("Your time is up! Press enter");
            timeOutTimer.Stop();
            bTimeOut = true;

        }

        




        // neighboring points can be determined by if (maxtrixGraph[x, y].Item1 == x)
        // relative direction is Item1 in the tuple
        // cost is Item2 in the tuple
        static (string, int)[,] matrixGraph = new (string, int)[,]
        {
                 //    A           B           C           D           E           F           G           H
          /*A*/  {("NE", 0),  ("S", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)},
          /*B*/  {(null, -1), (null, -1), ("S", 2),   ("E", 3),   (null, -1), (null, -1), (null, -1), (null, -1)},
          /*C*/  {(null, -1), ("N", 2),   (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 20)},
          /*D*/  {(null, -1), ("W", 3),   ("S", 5),   (null, -1), ("N", 2),   ("E", 4),   (null, -1), (null, -1)},
          /*E*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("S", 3),   (null, -1), (null, -1)},
          /*F*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), ("E", 1),   (null, -1)},
          /*G*/  {(null, -1), (null, -1), (null, -1), (null, -1), ("N", 0),   (null, -1), (null, -1), ("S", 2)},
          /*H*/  {(null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1), (null, -1)}
        };
        //Item1 is the index of the neighbor, Item2 is the direction and Item3 is the cost
        static (int, string, int)[][] listGraph = new (int, string, int)[][]
        {
            /*A*/ new (int, string, int)[] {(0, "N", 0), (0, "E", 0), (1, "S", 2)},
            /*B*/ new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null
        };
        // parallel arrays to store the weight, direction and room indexes
        // weight graph
        static int[][] wGraph = new int[][]
        {
            /*A*/ new int[] {0, 0, 2}
            /*B new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null  */
        };
        // room graphs: contains the indexes of the connected rooms
        static int[][] iGraph = new int[][]
        {
            /*A*/ new int[] {0, 0, 1}
            /*B new (int, string, int)[] {(2, "S", 2), (3, "E", 3)},
            new (int, string, int)[] {(1, "N", 2), (7, "S", 20)},
            new (int, string, int)[] {(1, "W", 3), (2, "S", 5), (4, "N", 2), (5, "E", 4)},
            new (int, string, int)[] {(5, "S", 3)},
            new (int, string, int)[] {(6, "E", 1)},
            new (int, string, int)[] {(4, "N", 0)},
            null  */
        };

        //Author: Shane Doherty
        //Purpose: Creates the functionality for the trvia game and the movement through the rooms
        //Restrictions: The program crashes after the second room, timer is not implemented, question answers are not randomly sorted (I tried everything and couldn't figure it out).
        static void Main(string[] args)
        {
            Random random1 = new Random();
            int hpDecreased = 0;
            int nRoom = 0;
            int playerHp = 1;
            string[] desc = new string[] {
                "A pit of lava is in the center, it is a bit too warm in here",
                "Snakes slither around your ankles, similar to that one scene in Indiana Jones",
                "The walls are electronic, with a constant beeping and the occasional booping",
                "A raised glacier is in the middle of this frozen room. It slowly descends as the water level rises",
                "A bland room with brick walls, similar to every building at RIT",
                "Mist shrouds the entire room, you can feel yourself stubbing your toe on literally everything at your feet",
                "The whole room is underwater, hope you can swim bro" };
            while (nRoom != 7 && playerHp != 0)
            {
                // if not room A and not room H then randomly reduce their HP such that they don't die
                if ((!(nRoom == 0 || nRoom == 7)) && playerHp != 1)
                {
                    hpDecreased = random1.Next(1, playerHp);
                    Console.WriteLine("You tripped on a rock!");
                    playerHp = playerHp - hpDecreased;
                }
                // display a desc of the room
                Console.WriteLine(desc[nRoom]);
                // display any exits from the room
                (int, string, int)[] thisRoomsNeighbors = listGraph[nRoom];
                int nExits = 0;
                foreach ((int, string, int) neighbor in thisRoomsNeighbors)
                {
                    if (playerHp > neighbor.Item3)
                    {
                        Console.WriteLine("There is an exit to the " + neighbor.Item2 + " which costs " + neighbor.Item3 + " HP");
                        ++nExits;
                    }
                }
                // display the hp
                Console.WriteLine($"You have {playerHp} HP");
                // ask the player if they want wager (w) for more hp or leave (l) the room only if there are nExits > 0
                if (nExits > 0)
                {
                    Console.WriteLine("Type 'l' if you want to leave this room");
                }
                Console.WriteLine("Type 'w' if you would like to wager for more HP");
                string sResponse;
                sResponse = Console.ReadLine();
                if (sResponse.ToLower() == "l" /* leaving room */ && nExits > 0 )
                {
                    Console.WriteLine("Enter a direction that was listed:");
                    bool bValid = false;
                    string sDirection;
                    while (!bValid)
                    {
                        sDirection = Console.ReadLine();
                        for (int nCntr = 0; nCntr < 8; ++nCntr)
                        {

                            if (matrixGraph[nRoom, nCntr].Item1.Contains(sDirection) && playerHp > matrixGraph[nRoom, nCntr].Item2 && matrixGraph[nRoom, nCntr].Item1 != null)
                            {
                                nRoom = nCntr;
                                playerHp -= matrixGraph[nRoom, nCntr].Item2;
                                bValid = true;
                                break;
                            }
                            
                        }
                        if (bValid == false)
                        {
                            Console.WriteLine("That isn't a valid direction");
                            break;
                        }

                    }
                }
                else
                {
                    int userNumber = 0;
                    int hpWagered = 0;
                    for (int i = 0; i < 1; i++)
                    {
                        Console.WriteLine("How much HP do you want to wager? Enter an integer: ");
                        string userResponse = Console.ReadLine();
                        try
                        {
                            userNumber = Int32.Parse(userResponse);
                            if (userNumber <= playerHp)
                            {
                                hpWagered = userNumber;
                            } else
                            {
                                Console.WriteLine("You have wagered too much");
                                i--;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("That is not a valid integer");
                            i--;
                        }
                    }
                    
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
                    //string[] triviaLines = new string[] { trivia.results[0].incorrect_answers[0], trivia.results[0].incorrect_answers[1],
                    //trivia.results[0].incorrect_answers[2], trivia.results[0].correct_answer };

                    List<string> triviaLines = new List<string>();
                    triviaLines.Add(trivia.results[0].incorrect_answers[0]);
                    triviaLines.Add(trivia.results[0].incorrect_answers[1]);
                    triviaLines.Add(trivia.results[0].incorrect_answers[2]);
                    triviaLines.Add(trivia.results[0].correct_answer);

                    Random random = new Random();
                    Console.WriteLine(trivia.results[0].question);
                    Console.WriteLine("------------");


                    int randomNumber = 0;
                    string randomLine = null;
                    List<string> answerList = new List<string>();


                    randomNumber = random.Next(0, 3);
                    Console.Write("1: ");
                    randomLine = triviaLines[randomNumber];
                    Console.WriteLine(randomLine);
                    answerList.Add(randomLine);
                    triviaLines.RemoveAt(randomNumber);

                    randomNumber = random.Next(0, 2);
                    Console.Write("2: ");
                    randomLine = triviaLines[randomNumber];
                    Console.WriteLine(randomLine);
                    answerList.Add(randomLine);
                    triviaLines.RemoveAt(randomNumber);


                    randomNumber = random.Next(0, 1);
                    Console.Write("3: ");
                    randomLine = triviaLines[randomNumber];
                    Console.WriteLine(randomLine);
                    answerList.Add(randomLine);
                    triviaLines.RemoveAt(randomNumber);


                    randomNumber = 0;
                    Console.Write("4: ");
                    randomLine = triviaLines[randomNumber];
                    Console.WriteLine(randomLine);
                    answerList.Add(randomLine);
                    triviaLines.RemoveAt(randomNumber);

                    answerList.ToArray();

                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter the number corresponding with the answer: ");
                    int userAnswerNumber = 0;

                    timeOutTimer = new Timer(5000);

                    //ElapsedEventHandler elapsedEventHandler;
                    //elapsedEventHandler = new ElapsedEventHandler(TimesUp);
                    //timeOutTimer.Elapsed += elapsedEventHandler;
                    //timeOutTimer.Start();
                    //bTimeOut = false;

                    for (int i = 0; i < 1; i++)
                    {
                        string userAnswer = Console.ReadLine();
                        try
                        {
                            userAnswerNumber = Int32.Parse(userAnswer);
                            if (!(userAnswerNumber < 1 || userAnswerNumber > 4))
                            {
                                if (answerList[userAnswerNumber - 1] == trivia.results[0].correct_answer)
                                {
                                    Console.WriteLine("Congratulations you earned HP!");
                                    playerHp = playerHp + hpWagered;

                                } else if (!(answerList[userAnswerNumber - 1] == trivia.results[0].correct_answer))
                                {
                                    Console.WriteLine("Oops you failed hope you don't die");
                                    playerHp = playerHp - hpWagered;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have entered an invalid number (1-4 please) ");
                                i--;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("That is not a valid integer");
                            i--;
                        }
                    }






                    // put the answers in random order
                    // prefix each answer with number 1-4 so the player only need to type the number
                    // 15 second timer
                }
            }
            Console.WriteLine("You have died");
        }
    }
}