using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
    public class Rover
    {
        #region Variables
            private int x;
            private int y;
            private char direction;
            private string route;
        #endregion
        #region Properties
            public int X
            {
                get { return x; }
                set { x = value; } 
            }

            public int Y
            {
                get { return y; }
                set { y = value; }
            }

            public char Direction
            {
                get { return direction; }
                set { direction = value; }
            }
            public  string Route
            {
                get { return route; }
                set { route = value; }
            }

        #endregion


        public Rover(int x,int y,char direction )
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}
