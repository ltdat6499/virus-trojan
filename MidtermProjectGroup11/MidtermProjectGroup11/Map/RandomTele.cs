using MidtermProjectGroup11.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class RandomTele : Piece
    {
        public RandomTele(FlowLayoutPanel position)
        {
            _position = position;
            _type = 5;
        }
        public int RandomPosition()
        {
            int result = RandomTool.Instance.Rand(1, 41);
            while (result == 21)
            {
                result = RandomTool.Instance.Rand(1, 41);
            }
            return result;
        }
    }
}
