using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Net;
using System.IO;

namespace Exam3Q2
{
    //Author: Shane Doherty
    //Purpose: To use a list graph and matrix graph to perform depdth first search and Djstrika shortest path algorithm
    //Restrictions: None
    class Program
    {
        //Matrix graph

        static int[,] mCGraph = new int[,]
        {
            //        Red       Navy        Sky     Grey        Orange      Purple      Yellow      Green

            /*Red*/{   -1,       1,         -1,       5,          -1,          -1,          -1,           -1  },


            /*Navy*/{  -1,       -1,         1,       -1,         -1,         -1,            8,           -1},


            /*Sky*/{   -1,        1,         -1,       0,          -1,         -1,           -1,           -1 },


            /*Grey*/{  -1,       -1,         0,       -1,          1,          -1,           -1,           -1 },


            /*Orange*/{ -1,      -1,        -1,       -1,         -1,          1,            -1,          -1 },


            /*Purple*/{ -1,      -1,        -1,       -1,         -1,         -1,             1,          -1 },


            /*Yellow*/{ -1,       -1,        -1,       -1,         -1,         -1,            -1,         6},


            /*Green*/{   -1,      -1,        -1,       -1,         -1,         -1,            -1,        -1 }
        };

        //List graph
        //(index of neighbor, cost)
        static (int, int)[][] listGraph = new (int, int)[][]
        {
            /* listGraph[0] Red*/ new (int, int)[] {(1, 1), (3, 5)},
            /* listGraph[1] Navy*/ new (int, int)[] {(2, 1), (6, 8)},
            /* listGraph[2] Sky*/ new (int, int)[] {(1, 1), (3, 0)},
            /* listGraph[3] Grey*/ new (int, int)[] {(2, 0), (4, 1)},
            /* listGraph[4] Orange*/ new (int, int)[] {(5, 1)},
            /* listGraph[5] Purple*/ new (int, int)[] {(6,  1)},
            /* listGraph[6] Yellow*/ new (int, int)[] {(7,  6)},
            /* listGraph[7] Green*/ null
        };



        static List<Node> game = new List<Node>();
        static void DFS(int nIndex)
        {
            bool[] visited = new bool[listGraph.Length];
            DFSUtil(nIndex, ref visited);
        }

        static void DFSUtil(int v, ref bool[] visited)
        {
            visited[v] = true;

            if (v == 0)
            {
                Console.Write("Red-> ");
            }
            if (v == 1)
            {
                Console.Write("Navy-> ");
            }
            if (v == 2)
            {
                Console.Write("Sky-> ");
            }
            if (v == 3)
            {
                Console.Write("Grey-> ");
            }
            if (v == 4)
            {
                Console.Write("Orange-> ");
            }
            if (v == 5)
            {
                Console.Write("Purple-> ");
            }
            if (v == 6)
            {
                Console.Write("Yellow-> ");
            }
            if (v == 7)
            {
                Console.Write("Green ");
            }

            (int, int)[] colorList = listGraph[v];

            if (colorList != null)
            {
                foreach ((int, int) neighbor in colorList)
                {
                    if (!visited[neighbor.Item1])
                    {
                        DFSUtil(neighbor.Item1, ref visited);
                    }
                }
            }
           
    
        }

        public class Node : IComparable<Node>
        {
            // any node-specific data here
            public int nState;

            public Node(int nState)
            {
                this.nState = nState;
                this.minCostToStart = int.MaxValue;
            }

            // fields needed for Dijkstra algorithm
            public List<Edge> edges = new List<Edge>();

            public int minCostToStart;
            public Node nearestToStart;
            public bool visited;

            public void AddEdge(int cost, Node connection)
            {
                Edge e = new Edge(cost, connection);
                edges.Add(e);
            }

            public int CompareTo(Node n)
            {
                return this.minCostToStart.CompareTo(n.minCostToStart);
            }
        }

        public class Edge : IComparable<Edge>
        {
            public int cost;
            public Node connectedNode;

            public Edge(int cost, Node connectedNode)
            {
                this.cost = cost;
                this.connectedNode = connectedNode;
            }
            public int CompareTo(Edge e)
            {
                return this.cost.CompareTo(e.cost);
            }

        }


        static public List<Node> GetShortestPathDijkstra()
        {
            DijstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(game[5]);
            BuildShortestPath(shortestPath, game[5]);
            shortestPath.Reverse();
            return (shortestPath);
        }


        static public void BuildShortestPath(List<Node> list, Node node)
        {
            if (node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static public void DijstraSearch()
        {
            Node start = game[2];

            start.minCostToStart = 0;
            List<Node> prioQueue = new List<Node>();

            prioQueue.Add(start);

            do
            {
                // sort method sorts the queue in place
                prioQueue.Sort();

                prioQueue = prioQueue.OrderBy(delegate (Node n) { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((Node n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => { return n.minCostToStart; }).ToList();
                prioQueue = prioQueue.OrderBy((n) => n.minCostToStart).ToList();
                prioQueue = prioQueue.OrderBy(n => n.minCostToStart).ToList();

                Node node = prioQueue.First();
                prioQueue.Remove(node);

                foreach (Edge cnn in node.edges)
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!prioQueue.Contains(childNode))
                        {
                            prioQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if (node == game[5])
                {
                    return;
                }
            } while (prioQueue.Any());
        }




        //Author: Shane Doherty
        //Purpose Main - Calls the Depth First Search method starting from index 0, also calls Dijstra sort
        //Restrictions: None
        static void Main(string[] args)
        {
            Random rand = new Random();

            string sState;

            int nUserState;

            int nMoves = 0;

            Node node;
            int i = 0;


            DFS(0);

            for (i = 0; i < listGraph.Length; ++i)
            {
                node = new Node(i);
                game.Add(node);
            }

            for (i = 0; i < listGraph.Length; ++i)
            {
                (int, int)[] colorList = listGraph[i];


                for (int cCntr = 0; colorList != null && cCntr < colorList.Length; ++cCntr)
                {
                    game[i].AddEdge(colorList[cCntr].Item2, game[colorList[cCntr].Item1]);
                }

                game[i].edges.Sort();
            }




        }
    }
}
