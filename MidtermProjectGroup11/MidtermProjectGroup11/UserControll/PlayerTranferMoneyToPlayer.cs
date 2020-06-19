using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace MidtermProjectGroup11.UserControll
{
    public partial class PlayerTranferMoneyToPlayer : UserControl
    {
        private int player, desPlayer, money, transMoney, moneyAfter, desMoney;

        private void tmTran_Tick(object sender, EventArgs e)
        {
            if (lblTranMoney.Location.X > pbxDesPlayer.Location.X)
            {
                tmTran.Stop();
                lblDesMoney.Text = desMoney + transMoney + "$";
                lblTranMoney.Visible = false;
            }
            lblTranMoney.Location = new Point(lblTranMoney.Location.X + 30, lblTranMoney.Location.Y);
        }
        public PlayerTranferMoneyToPlayer()
        {
            InitializeComponent();
        }
        public PlayerTranferMoneyToPlayer(int player, int desPlayer, int money, int desMoney, int transMoney)
        {
            InitializeComponent();
            this.player = player;
            this.desPlayer = desPlayer;
            this.money = money;
            this.desMoney = desMoney;
            this.transMoney = transMoney;
            moneyAfter = money - transMoney;
            lblDesMoney.Text = desMoney + "$"; 
            lblMoney.Text = money + "$";
            lblTranMoney.Text = transMoney + "$";
            switch (player)
            {
                case 1:
                    pbxPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "blue.png"));
                    break;
                case 2:
                    pbxPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "red.png"));
                    break;
                case 3:
                    pbxPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "yellow.png"));
                    break;
                case 4:
                    pbxPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "white.png"));
                    break;
                default:
                    break;
            }
            switch (desPlayer)
            {
                case 1:
                    pbxDesPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "blue.png"));
                    break;
                case 2:
                    pbxDesPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "red.png"));
                    break;
                case 3:
                    pbxDesPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "yellow.png"));
                    break;
                case 4:
                    pbxDesPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "white.png"));
                    break;
                default:
                    break;
            }
            Thread.Sleep(200);
            tmTran.Start();
            lblTranMoney.Visible = true;
            lblMoney.Text = moneyAfter + "$";
        }

    }
}
