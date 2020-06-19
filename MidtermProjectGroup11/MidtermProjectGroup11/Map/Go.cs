using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Go : Piece
    {
        public Go(FlowLayoutPanel position)
        {
            _position = position;
            _type = 0;
        }
        public int SalaryWhenPass(int count)
        {
            if (count > 0)
            {
                return 200;
            }
            return 0;
        }
    }
}
