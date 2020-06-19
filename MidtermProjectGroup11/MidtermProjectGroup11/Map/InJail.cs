using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class InJail : Piece
    {
        public InJail(FlowLayoutPanel position)
        {
            _position = position;
            _type = 7;
        }
        public int JailFee()
        {
            return 500;
        }
    }
}
