using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Place : Piece
    {
        protected int _group;
        protected int _price;
        protected int _mortgage;
        protected int _rent;
        protected int _ownerPlayer = 0;
        protected Panel _owner;

        public Panel Owner { get => _owner; }
        public int Price { get => _price; }
        public int Mortgage { get => _mortgage; }
        public int Rent { get => _rent; }
        public int OwnerPlayer { get => _ownerPlayer; }
        public int Group { get => _group; }

        public int BuyPiece(int owner, int totalMoney)
        {
            /*
             Hàm sẽ hỗ trợ quá trình mua đất cho người chơi
             Nếu giá trị tổng hầu bao quả ng chơi lớn hơn hoặc bằng giá trị mảnh đất => Bán và trả về tiền thừa
             Nếu không trả về -1 và không cho mua
             */
            if (totalMoney >= _price)
            {
                _ownerPlayer = owner;
                return totalMoney - _price;
            }
            return -1;
        }
        public int SellPiece()
        {

            _ownerPlayer = 0;
            return _mortgage;
        }
    }
}
