using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class GoToJail : Piece
    {
        public GoToJail(FlowLayoutPanel position)
        {
            _position = position;
            _type = 6;
        }
        public string TeleTo()
        {
            return "Position_11_1";
        }
    }
}
