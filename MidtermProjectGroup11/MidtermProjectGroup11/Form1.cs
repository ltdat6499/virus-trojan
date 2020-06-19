using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using MidtermProjectGroup11.Command;
using MidtermProjectGroup11.GamePlay;
using MidtermProjectGroup11.Interface;
using MidtermProjectGroup11.Invoker;
using MidtermProjectGroup11.Map;
using MidtermProjectGroup11.Tools;
using MidtermProjectGroup11.UserControll;

namespace MidtermProjectGroup11
{
    public partial class frm_Map : MaterialForm
    {
        #region Init
        GamePlayControll gamePlay;
        public static List<Piece> ListPiece;
        public static List<Player> ListPlayer;
        public static int currentPlayer = 1;
        public static string resultString;
        public static bool isEndGame = false;
        public static int winnerPlayer = 0;
        public frm_Map()
        {
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
            InitializeComponent();

            gamePlay = new GamePlayControll(this);
            Execute(gamePlay, new Modify(), new GamePlayCommand(gamePlay, Enum.PlayerAction.SetListPiece));
            Execute(gamePlay, new Modify(), new GamePlayCommand(gamePlay, Enum.PlayerAction.SetListPlayer));

            AllPlayerGraphicSet();
        }
        private void Execute(GamePlayControll gamePlayControll, Modify modifyGamePlay, ICommand GamePlayCommand)
        {
            modifyGamePlay.SetCommand(GamePlayCommand);
            modifyGamePlay.Invoke();
        }
        private void Execute(Piece piece, Modify modifyPiece, ICommand pieceCommand)
        {
            modifyPiece.SetCommand(pieceCommand);
            modifyPiece.Invoke();
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;
            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }
            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                return;
            }
            base.WndProc(ref m);
        }
        #endregion

        #region Roll, Show Info, End Turn 

        public static int diceResult1;
        public static int diceResult2;
        public async void StartPlayerRoll()
        {
            for (int i = 0; i < 20; i++)
            {
                RollEvent();
                Thread.Sleep(200);
            }
            RealRollResult();
        }
        private void RollEvent()
        {
            //Tạo kết quả Roll
            int result_dice_1 = RandomTool.Instance.Rand(1, 13);
            int result_dice_2 = RandomTool.Instance.Rand(1, 13);

            //Tạo đường dẫn đến ảnh của kết quả Roll
            string dice_1_path = Path.Combine(Application.StartupPath, @"Images", "Dice", result_dice_1 + ".png");
            string dice_2_path = Path.Combine(Application.StartupPath, @"Images", "Dice", result_dice_2 + ".png");

            //Gán ảnh của kết quả Roll vào biến
            pnl_Dice_1.BackgroundImage = new Bitmap(dice_1_path);
            pnl_Dice_2.BackgroundImage = new Bitmap(dice_2_path);
        }
        private void RealRollResult()
        {
            //Tạo đường dẫn đến ảnh của kết quả Roll
            string dice_1_path = Path.Combine(Application.StartupPath, @"Images", "Dice", diceResult1 + ".png");
            string dice_2_path = Path.Combine(Application.StartupPath, @"Images", "Dice", diceResult2 + ".png");

            //Gán ảnh của kết quả Roll vào biến
            pnl_Dice_1.BackgroundImage = new Bitmap(dice_1_path);
            pnl_Dice_2.BackgroundImage = new Bitmap(dice_2_path);
        }
        private void ShowPieceInfo(Object sender, EventArgs args)
        {
            int index = Convert.ToInt32((sender as FlowLayoutPanel).Tag);
            Execute(ListPiece[index], new Modify(), new PieceCommand(ListPiece[index], Enum.PieceAction.ShowPieceInfo));
            MessageBox.Show(resultString);
        }
        private void btn_Roll_Click_1(object sender, EventArgs e)
        {
            Execute(gamePlay, new Modify(), new GamePlayCommand(gamePlay, Enum.PlayerAction.MoveForMainPlayer));
            btn_Endturn.Enabled = true;
            btn_Roll.Enabled = false;
            Execute(gamePlay, new Modify(), new GamePlayCommand(gamePlay, Enum.PlayerAction.IsEndGame));
            if (isEndGame)
            {
                MessageBox.Show("Player " + winnerPlayer + " won XDDDDDDDDDDDDDD");
            }
        }
        private void btn_Endturn_Click(object sender, EventArgs e)
        {
            btn_Endturn.Enabled = false;
            btn_Roll.Enabled = true;
            pnl_Effect.Controls.Clear();
            AllPlayerGraphicSet();
        }
        #endregion

        #region Graphic
        public void TransMoneyToBank(int money)
        {
            pnl_Effect.Controls.Clear();
            pnl_Effect.Controls.Add(new PlayerTranferMoneyToBank(currentPlayer, ListPlayer[currentPlayer].Money, money));
        }
        public void TransMoneyToPlayer(int money, int desPlayer)
        {
            pnl_Effect.Controls.Clear();
            pnl_Effect.Controls.Add(new PlayerTranferMoneyToPlayer(currentPlayer, desPlayer, ListPlayer[currentPlayer].Money, ListPlayer[desPlayer].Money, money));
        }
        public void TransMoneyFromBankToPlayer(int money)
        {
            pnl_Effect.Controls.Clear();
            pnl_Effect.Controls.Add(new BankTranferMoneyToPlayer(currentPlayer, ListPlayer[currentPlayer].Money, money));
        }
        public void AllPlayerGraphicSet()
        {
            List<int> sequencePlayer = new List<int>();
            switch (currentPlayer)
            {
                case 1:
                    sequencePlayer.Add(2);
                    sequencePlayer.Add(3);
                    sequencePlayer.Add(4);
                    break;
                case 2:
                    sequencePlayer.Add(3);
                    sequencePlayer.Add(4);
                    sequencePlayer.Add(1);
                    break;
                case 3:
                    sequencePlayer.Add(4);
                    sequencePlayer.Add(1);
                    sequencePlayer.Add(2);
                    break;
                case 4:
                    sequencePlayer.Add(1);
                    sequencePlayer.Add(2);
                    sequencePlayer.Add(3);
                    break;
            }

            int countAlive = 0;
            foreach (var item in ListPlayer)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.IsALive)
                {
                    countAlive++;
                }
            }
            switch (countAlive)
            {
                case 3:
                    pnl_NextNextNextPlayer.Visible = false;
                    pnl_NextNextNextPlayerExtra.Visible = false;
                    lbl_NextNextNextPlayerMoney.Visible = false;
                    break;
                case 2:
                    pnl_NextNextNextPlayer.Visible = false;
                    pnl_NextNextNextPlayerExtra.Visible = false;
                    lbl_NextNextNextPlayerMoney.Visible = false;
                    pnl_NextNextPlayer.Visible = false;
                    pnl_NextNextPlayerExtra.Visible = false;
                    lbl_NextNextPlayerMoney.Visible = false;
                    break;
                default:
                    break;
            }

            List<int> deadPlayer = new List<int>();
            for (int i = 1; i < ListPlayer.Count; i++)
            {
                if (!ListPlayer[i].IsALive)
                {
                    deadPlayer.Add(i);
                }
            }

            switch (currentPlayer)
            {
                case 1:
                    pnl_CurrentPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "blue.png"));
                    lbl_CurrentPlayerMoney.Text = ListPlayer[1].Money + "$";
                    if (ListPlayer[1].PrisonBreak > 0)
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                    }
                    else
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = null;
                    }
                    break;
                case 2:
                    pnl_CurrentPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "red.png"));
                    lbl_CurrentPlayerMoney.Text = ListPlayer[2].Money + "$";
                    if (ListPlayer[2].PrisonBreak > 0)
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                    }
                    else
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = null;
                    }
                    break;
                case 3:
                    pnl_CurrentPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "yellow.png"));
                    lbl_CurrentPlayerMoney.Text = ListPlayer[3].Money + "$";
                    if (ListPlayer[3].PrisonBreak > 0)
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                    }
                    else
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = null;
                    }
                    break;
                case 4:
                    pnl_CurrentPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "white.png"));
                    lbl_CurrentPlayerMoney.Text = ListPlayer[4].Money + "$";
                    if (ListPlayer[4].PrisonBreak > 0)
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                    }
                    else
                    {
                        pnl_CurrentPlayerExtra.BackgroundImage = null;
                    }
                    break;
            }

            foreach (int item in sequencePlayer)
            {
                if (!deadPlayer.Contains(item))
                {
                    switch (item)
                    {
                        case 1:
                            pnl_NextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "blue.png"));
                            lbl_NextPlayerMoney.Text = ListPlayer[1].Money + "$";
                            if (ListPlayer[1].PrisonBreak > 0)
                            {
                                pnl_NextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 2:
                            pnl_NextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "red.png"));
                            lbl_NextPlayerMoney.Text = ListPlayer[2].Money + "$";
                            if (ListPlayer[2].PrisonBreak > 0)
                            {
                                pnl_NextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 3:
                            pnl_NextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "yellow.png"));
                            lbl_NextPlayerMoney.Text = ListPlayer[3].Money + "$";
                            if (ListPlayer[3].PrisonBreak > 0)
                            {
                                pnl_NextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 4:
                            pnl_NextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "white.png"));
                            lbl_NextPlayerMoney.Text = ListPlayer[4].Money + "$";
                            if (ListPlayer[4].PrisonBreak > 0)
                            {
                                pnl_NextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                    }
                    sequencePlayer.Remove(item);
                    break;
                }
            }

            foreach (int item in sequencePlayer)
            {
                if (!deadPlayer.Contains(item))
                {
                    switch (item)
                    {
                        case 1:
                            pnl_NextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "blue.png"));
                            lbl_NextNextPlayerMoney.Text = ListPlayer[1].Money + "$";
                            if (ListPlayer[1].PrisonBreak > 0)
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 2:
                            pnl_NextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "red.png"));
                            lbl_NextNextPlayerMoney.Text = ListPlayer[2].Money + "$";
                            if (ListPlayer[2].PrisonBreak > 0)
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 3:
                            pnl_NextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "yellow.png"));
                            lbl_NextNextPlayerMoney.Text = ListPlayer[3].Money + "$";
                            if (ListPlayer[3].PrisonBreak > 0)
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 4:
                            pnl_NextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "white.png"));
                            lbl_NextNextPlayerMoney.Text = ListPlayer[4].Money + "$";
                            if (ListPlayer[4].PrisonBreak > 0)
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                    }
                    sequencePlayer.Remove(item);
                    break;
                }
            }

            foreach (int item in sequencePlayer)
            {
                if (!deadPlayer.Contains(item))
                {
                    switch (item)
                    {
                        case 1:
                            pnl_NextNextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "blue.png"));
                            lbl_NextNextNextPlayerMoney.Text = ListPlayer[1].Money + "$";
                            if (ListPlayer[1].PrisonBreak > 0)
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 2:
                            pnl_NextNextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "red.png"));
                            lbl_NextNextNextPlayerMoney.Text = ListPlayer[2].Money + "$";
                            if (ListPlayer[2].PrisonBreak > 0)
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 3:
                            pnl_NextNextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "yellow.png"));
                            lbl_NextNextNextPlayerMoney.Text = ListPlayer[3].Money + "$";
                            if (ListPlayer[3].PrisonBreak > 0)
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                        case 4:
                            pnl_NextNextNextPlayer.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Player", "white.png"));
                            lbl_NextNextNextPlayerMoney.Text = ListPlayer[4].Money + "$";
                            if (ListPlayer[4].PrisonBreak > 0)
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "Extra", "breakJailCard.png"));
                            }
                            else
                            {
                                pnl_NextNextNextPlayerExtra.BackgroundImage = null;
                            }
                            break;
                    }
                    sequencePlayer.Remove(item);
                    break;
                }
            }
        }
        #endregion
    }
}
