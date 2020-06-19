using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class VisitJail : Piece
    {
        public VisitJail(FlowLayoutPanel position)
        {
            _position = position;
            _type = 8;
        }
        public int VisitFee(int numPersonInJail)
        {
            return 500 * numPersonInJail;
        }
    }
}
