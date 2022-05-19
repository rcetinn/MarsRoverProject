using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverProject
{
   public sealed class Dimension
    {    
        #region Variables
        private int x;
        private int y;
       
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

       
        #endregion


        private Dimension()
        {
        }

        private static Dimension instance = null;
        public static Dimension Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Dimension();
                }
                return instance;
            }
        }


    }
}

