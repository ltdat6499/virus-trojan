using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Tax : Piece
    {
        private int _taxType;

        public Tax(FlowLayoutPanel position, int taxType)
        {
            _type = 4;
            _taxType = taxType;
            _position = position;
        }

        public int CostForVisitor(int totalMoney)
        {
            if (_taxType == 1)
            {
                if (totalMoney * 10 / 100 < 200)
                {
                    return (int)totalMoney * 10 / 100 - 1;
                }
                else
                {
                    return 200;
                }
            }
            else
            {
                return 75;
            }
        }
    }
}
