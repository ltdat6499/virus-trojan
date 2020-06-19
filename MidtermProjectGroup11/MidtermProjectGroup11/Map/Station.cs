using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Station : Place
    {
        public Station(Panel owner, FlowLayoutPanel position, int group, int price, int mortgage, int rent)
        {
            _group = group;
            _price = price;
            _mortgage = mortgage;
            _rent = rent;
            _type = 2;
            _position = position;
            _owner = owner;
        }
        public Tuple<int, int> CostForVisitor(int PieceNum)
        {
            //Hàm trả về phí tham quan cho khách

            //Set tiền phạt khi có nhà hoặc khách sạn
            int rent = 0;

            // Tổng chi phí cho khách viến thăm = chi phí tạm x số đất cùng nhóm đang sở hữu
            int resultcost = rent * PieceNum;
            return new Tuple<int, int>(_ownerPlayer, resultcost);
        }
        public override string ToString()
        {
            string result = "Type Station\n";
            result += "Price: " + _price + "\n";
            result += "Mortgage: " + _mortgage + "\n";
            result += "Cost = " + _rent + " * total station of owner have";
            frm_Map.resultString = result;
            return result;
        }
    }
}
