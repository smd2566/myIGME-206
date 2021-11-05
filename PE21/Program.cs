using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE21
{
    
    class Program
    {

        //Author: Shane Doherty
        //Purpose: Creates an adjaceny matrix / list based on the given diagram
        //Restrictions: None
        static int[,] mGraph = new int[,]
        {              //0       //1       //2       //3       //4     //5      //6      //7
                     /* A */   /* B */   /* C */   /* D */  /* E */  /* F */  /* G */  /* H */ 
           /* A */ { 0,       2,        -1,       -1,        -1,     -1,      -1,       -1},
           /* B */ { -1,       -1,        2,      3,         -1,       -1,     -1,      -1},
           /* C */ { -1,       2,        -1,     -1,         -1,       -1,    -1,        20},
           /* D */ { -1,       3,        5,      -1,         2,       4,       -1,        -1},
           /* E */ { -1,       -1,       -1,      -1,        -1,       3,     -1,        -1},
           /* F */ { -1,       -1,        -1,      -1,         -1,   -1,       1,     -1},
           /* G */ { -1,       -1,        -1,        -1,        0,   -1,    -1,        2},
           /* H */ { -1,       -1,        -1,      -1,          -1,   -1,    -1,        -1}
        };

        // parallel adjacency lists
        // lGraph stores the connected nodes
        static int[][] lGraph = new int[][]
        {
            /* A */ new int[] { 0, 1 },    
            /* B */ new int[] { 2, 3 },    
            /* C */ new int[] { 1, 7 }, 
            /* D */ new int[] { 1, 2, 4, 5 },
            /* E */ new int[] { 5 },
            /* F */ new int[] { 6 },
            /* G */ new int[] { 4, 7 },
   
        };

        // wGraph stores the edge weights
        static int[][] wGraph = new int[][]
        {
            /* A */ new int[] { 2 },
            /* B */ new int[] { 2, 3 },
            /* C */ new int[] { 2, 20},
            /* D */ new int[] { 2, 4, 5 },
            /* E */ new int[] { 3 },
            /* F */ new int[] { 1 },
            /* G */ new int[] { 0, 2 },
            
        };

        
        static void Main(string[] args)
        {
            
        }
    }
}