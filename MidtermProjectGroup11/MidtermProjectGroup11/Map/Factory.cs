using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Factory : Place
    {
        public Factory(Panel owner, FlowLayoutPanel position, int group, int price, int mortgage)
        {
            _group = group;
            _price = price;
            _mortgage = mortgage;
            _type = 3;
            _position = position;
            _owner = owner;
        }
        public Tuple<int, int> CostForVisitor(int sumDice, int pieceNum)
        {
            return new Tuple<int, int>(_ownerPlayer, sumDice * pieceNum * 10);
        }
        public override string ToString()
        {
            string result = "Type Factory\n";
            result += "Price: " + _price + "\n";
            result += "Mortgage: " + _mortgage + "\n";
            result += "Cost = Sum of two dice * 10 * number of factory of owner have";
            frm_Map.resultString = result;
            return result;
        }
    }
}
