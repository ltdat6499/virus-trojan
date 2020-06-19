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
    public partial class BankTranferMoneyToPlayer : UserControl
    {
        private int player, money, transMoney, moneyAfter;
        public BankTranferMoneyToPlayer()
        {
            InitializeComponent();
        }
        private void tmTran_Tick(object sender, EventArgs e)
        {
            if (lblTranMoney.Location.X > pbxPlayer.Location.X)
            {
                tmTran.Stop();
                lblTranMoney.Visible = false;
                lblMoney.Text = moneyAfter + "$";
            }
            lblTranMoney.Location = new Point(lblTranMoney.Location.X - 30, lblTranMoney.Location.Y);
        }
        public BankTranferMoneyToPlayer(int player, int money, int transMoney)
        {
            InitializeComponent();
            this.player = player;
            this.money = money;
            this.transMoney = transMoney;
            moneyAfter = money + transMoney;
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
            Thread.Sleep(200);
            lblTranMoney.Visible = true;
            tmTran.Start();
        }
    }
}
