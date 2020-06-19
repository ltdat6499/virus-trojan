using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjectGroup11.Tools
{
    public class RandomTool
    {
        private Random rand = new Random();
        private static RandomTool instance;

        public static RandomTool Instance
        {
            get
            {
                if (instance == null)
                    instance = new RandomTool();
                return RandomTool.instance;
            }
            private set
            {
                RandomTool.instance = value;
            }
        }

        //Function
        public int Rand(int startAt, int endBefore)
        {
            return rand.Next(startAt, endBefore);
        }
    }
}
