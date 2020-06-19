using MidtermProjectGroup11.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.Map
{
    public class ChanceAndCommunityChest : Piece
    {
        private int _side;

        public ChanceAndCommunityChest(int side, FlowLayoutPanel position)
        {
            _side = side;
            _type = 9;
            _position = position;
        }

        public int Side { get => _side; }

        public int ChanceAction()
        {
            int randomChoose = RandomTool.Instance.Rand(1, 11);
            //string result = "";
            //switch (randomChoose)
            //{
            //    case 1: result = "Advance to 'Go'"; break;
            //    case 2: result = "Advance token to nearest Utility"; break;
            //    case 3: result = "Advance token to the nearest Railroad and pay owner twice the rental to which he/she {he} is otherwise entitled"; break;
            //    case 4: result = "Get out of Jail Free"; break;
            //    case 5: result = "Go Back Three {3} Space"; break;
            //    case 6: result = "Go to Jail"; break;
            //    case 7: result = "Make general repairs on all your property"; break;
            //    case 8: result = "Pay poor tax of $15"; break;
            //    case 9: result = "You have been elected Chairman of the Board. Pay each player $50"; break;
            //    case 10:result = "You have won a crossword competition. Collect $100"; break;
            //}
            return randomChoose;
        }

        public int ChestAction()
        {
            int randomChoose = RandomTool.Instance.Rand(1, 11);
            //string result = "";
            //switch (randomChoose)
            //{
            //    case 1: result = "Doctor's fees. Pay $50"; break;
            //    case 2: result = "Go to Jail. Go directly to jail. Do not pass Go, Do not collect $200"; break;
            //    case 3: result = "Grand Opera Night. Collect $50 from every player for opening night seats"; break;
            //    case 4: result = "Income tax refund. Collect $20"; break;
            //    case 5: result = "Life insurance matures – Collect $100"; break;
            //    case 6: result = "Hospital Fees. Pay $50"; break;
            //    case 7: result = "School fees. Pay $50"; break;
            //    case 8: result = "Receive $25 consultancy fee"; break;
            //    case 9: result = "You are assessed for street repairs: Pay $40 per house and $115 per hotel you own"; break;
            //    case 10:result = "You have won second prize in a beauty contest. Collect $10"; break;
            //}
            return randomChoose;
        }
    }
}
