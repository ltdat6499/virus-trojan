using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class Land : Place
    {
        private Panel _house1;
        private Panel _house2;
        private Panel _house3;

        private int _rentOneHouse;
        private int _rentTwoHouse;
        private int _rentThreeHouse;
        private int _rentHotel;

        private int _housePrice;
        private int _hotelPrice;

        private int _houseMortgage;
        private int _hotelMortgage;

        private int _houseNumber = 0;
        private int _hotelNumber = 0;

        public int HouseNumber { get => _houseNumber; }
        public int HotelNumber { get => _hotelNumber; }
        public Panel House1 { get => _house1; }
        public Panel House2 { get => _house2; }
        public Panel House3 { get => _house3; }
        public int HouseMortgage { get => _houseMortgage; }
        public int HotelMortgage { get => _hotelMortgage; }
        public int HousePrice { get => _housePrice; }
        public int HotelPrice { get => _hotelPrice; }

        public Land(int group, int price, int mortgage,
    int rent, int rentOneHouse, int rentTwoHouse, int rentThreeHouse,
    int rentHotel, int housePrice, int hotelPrice, int houseMortgage,
    int hotelMortgage, FlowLayoutPanel position, Panel owner, Panel house1, Panel house2, Panel house3)
        {
            _type = 1;
            _group = group;
            _price = price;
            _mortgage = mortgage;
            _rent = rent;
            _rentOneHouse = rentOneHouse;
            _rentTwoHouse = rentTwoHouse;
            _rentThreeHouse = rentThreeHouse;
            _rentHotel = rentHotel;
            _housePrice = housePrice;
            _hotelPrice = hotelPrice;
            _houseMortgage = houseMortgage;
            _hotelMortgage = hotelMortgage;
            _position = position;
            _owner = owner;
            _house1 = house1;
            _house2 = house2;
            _house3 = house3;
        }

        public Tuple<int, int> CostForVisitor(int PieceNum)
        {
            //Hàm trả về phí tham quan cho khách

            //Set tiền phạt khi có nhà hoặc khách sạn
            int rent = 0;
            if (_houseNumber > 0)
            {
                switch (_houseNumber)
                {
                    case 1:
                        rent = _rentOneHouse;
                        break;
                    case 2:
                        rent = _rentTwoHouse;
                        break;
                    case 3:
                        rent = _rentThreeHouse;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (_hotelNumber)
                {
                    case 0:
                        rent = _rent;
                        break;
                    case 1:
                        rent = _rentHotel;
                        break;
                    default:
                        break;
                }
            }

            // Tổng chi phí cho khách viến thăm = chi phí tạm x số đất cùng nhóm đang sở hữu
            int resultcost = rent * PieceNum;
            return new Tuple<int, int>(_ownerPlayer, resultcost);
        }

        public override string ToString()
        {
            string result = "Type Land\n";
            result += "Price: " + _price + "\n";
            result += "Mortgage: " + _mortgage + "\n";
            result += "Cost = " + _rent + "\n";
            result += "Cost 1 house = " + _rentOneHouse + "\n";
            result += "Cost 2 house = " + _rentTwoHouse + "\n";
            result += "Cost 3 house = " + _rentThreeHouse + "\n";
            result += "Cost hotel = " + _rentHotel + "\n";
            result += "Total Cost = Cost * total land in group of owner\n";
            result += "Price house = " + _housePrice + "\n";
            result += "Price hotel = " + _hotelPrice + "\n";
            result += "Mortgage house = " + _houseMortgage + "\n";
            result += "Mortgage hotel = " + _hotelMortgage;
            frm_Map.resultString = result;
            return result;
        }

        public int BuyHouse(int totalMoney)
        {
            /*
             Hàm hỗ trợ quá trình mua nhà khi đã sở hữu đất
             Trả về -1 nếu hầu bao của owner < giá mua
             Trả về tiền thừa sau khi mua
             */
            if (totalMoney < _housePrice)
            {
                return -1;
            }

            _houseNumber++;
            return totalMoney - HotelPrice;
        }

        public int BuyHotel(int totalMoney)
        {
            /*
             Hàm hỗ trợ quá trình mua khách sạn khi đã sở hữu đất
             Trả về -1 nếu hầu bao của owner < giá mua hoặc đã sở hữu khách sạn rồi
             Trả về tiền thừa sau khi mua
             Ngoài ra sau khi mua khách sạn sẽ thay thế 3 nhà nên biến đếm số nhà sẽ được reset
             Lưu ý: chỉ được phép mua 1 khách sạn
             */
            if (totalMoney < HotelPrice || _hotelNumber > 0)
            {
                return -1;
            }
            _houseNumber = 0;
            _hotelNumber = 1;
            return totalMoney - HotelPrice;
        }

        public int SellHouse()
        {
            _houseNumber--;
            _hotelNumber = 0;
            return _houseMortgage;
        }
        public int SellHotel()
        {
            _hotelNumber = 0;
            _hotelNumber = 0;
            return HotelMortgage;
        }
    }
}
