using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Piece
    {
        protected FlowLayoutPanel _position;
        protected int _type;

        public FlowLayoutPanel Position { get => _position; }
        public int Type { get => _type; }

    }
}
