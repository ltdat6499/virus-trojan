using MidtermProjectGroup11.Map;
using MidtermProjectGroup11.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.GamePlay
{
    public class GamePlayControll
    {
        #region Init 
        private int _currentPlayer = 1;
        private frm_Map _form;
        private List<Piece> _listPiece;
        private List<Player> _listPlayer;

        public List<Piece> ListPiece { get => _listPiece; }

        public List<Player> ListPlayer { get => _listPlayer; }

        public int CurrentPlayer { get => _currentPlayer; set => _currentPlayer = value; }

        public GamePlayControll(Control parentCntl)
        {
            _form = parentCntl as frm_Map;

            List<Player> listPlayer = new List<Player>();
            listPlayer.Add(null);
            listPlayer.Add(new Player("Player 1", Color.DarkBlue, (PictureBox)FormSupport.Instance.GetControlByName(parentCntl, "Player_1")));
            listPlayer.Add(new Player("Player 2", Color.Maroon, (PictureBox)FormSupport.Instance.GetControlByName(parentCntl, "Player_2")));
            listPlayer.Add(new Player("Player 3", Color.Yellow, (PictureBox)FormSupport.Instance.GetControlByName(parentCntl, "Player_3")));
            listPlayer.Add(new Player("Player 4", Color.Silver, (PictureBox)FormSupport.Instance.GetControlByName(parentCntl, "Player_4")));
            _listPlayer = listPlayer;

            List<FlowLayoutPanel> listPosition = new List<FlowLayoutPanel>();
            listPosition.Add(null);
            for (int i = 1; i <= 40; i++)
            {
                listPosition.Add((FlowLayoutPanel)FormSupport.Instance.GetControlByName(parentCntl, "Position_" + i));
            }
            listPosition.Add((FlowLayoutPanel)FormSupport.Instance.GetControlByName(parentCntl, "Position_11_1"));

            int[] indexOwnerList = new int[28] { 2, 4, 6, 7, 9, 10, 12, 13, 14, 15, 16, 17, 19, 20, 22, 24, 25, 26, 27, 28, 29, 30, 32, 33, 35, 36, 38, 40 };
            List<Panel> listOwner = new List<Panel>();
            List<List<Panel>> listHouse = new List<List<Panel>>();
            for (int i = 0; i < 41; i++)
            {
                listHouse.Add(new List<Panel>());
                listOwner.Add(null);
            }
            for (int i = 0; i < 28; i++)
            {
                listOwner[indexOwnerList[i]] = (Panel)FormSupport.Instance.GetControlByName(parentCntl, "Owner_" + indexOwnerList[i]);
                listHouse[indexOwnerList[i]].Add(null);
                for (int j = 1; j <= 3; j++)
                {
                    listHouse[indexOwnerList[i]].Add((Panel)FormSupport.Instance.GetControlByName(parentCntl, "House_" + indexOwnerList[i] + "_" + j));
                }
            }

            List<Piece> listPiece = new List<Piece>();
            listPiece.Add(null);
            listPiece.Add(new Go(listPosition[1]));
            listPiece.Add(new Land(1, 60, 30, 2, 30, 90, 180, 450, 50, 50, 25, 25, listPosition[2], listOwner[2], (listHouse[2])[1], (listHouse[2])[2], (listHouse[2])[3]));
            listPiece.Add(new ChanceAndCommunityChest(1, listPosition[3]));
            listPiece.Add(new Land(1, 60, 30, 4, 60, 180, 300, 450, 50, 50, 25, 25, listPosition[4], listOwner[4], (listHouse[4])[1], (listHouse[4])[2], (listHouse[4])[3]));
            listPiece.Add(new Tax(listPosition[5], 1));
            listPiece.Add(new Station(listOwner[6], listPosition[6], 2, 200, 100, 25));
            listPiece.Add(new Land(3, 100, 50, 6, 90, 270, 910, 550, 50, 50, 25, 25, listPosition[7], listOwner[7], (listHouse[7])[1], (listHouse[7])[2], (listHouse[7])[3]));
            listPiece.Add(new ChanceAndCommunityChest(2, listPosition[8]));
            listPiece.Add(new Land(3, 100, 50, 6, 90, 270, 910, 550, 50, 50, 25, 25, listPosition[9], listOwner[9], (listHouse[9])[1], (listHouse[9])[2], (listHouse[9])[3]));
            listPiece.Add(new Land(3, 120, 60, 8, 120, 300, 900, 600, 50, 50, 25, 25, listPosition[10], listOwner[10], (listHouse[10])[1], (listHouse[10])[2], (listHouse[10])[3]));
            listPiece.Add(new VisitJail(listPosition[11]));
            listPiece.Add(new Land(4, 140, 70, 10, 150, 450, 1000, 750, 100, 100, 50, 50, listPosition[12], listOwner[12], (listHouse[12])[1], (listHouse[12])[2], (listHouse[12])[3]));
            listPiece.Add(new Factory(listOwner[13], listPosition[13], 10, 200, 100));
            listPiece.Add(new Land(4, 140, 70, 10, 150, 450, 1000, 750, 100, 100, 50, 50, listPosition[14], listOwner[14], (listHouse[14])[1], (listHouse[14])[2], (listHouse[14])[3]));
            listPiece.Add(new Land(4, 160, 80, 12, 180, 540, 1200, 900, 100, 100, 50, 50, listPosition[15], listOwner[15], (listHouse[15])[1], (listHouse[15])[2], (listHouse[15])[3]));
            listPiece.Add(new Station(listOwner[16], listPosition[16], 2, 200, 100, 50));
            listPiece.Add(new Land(5, 180, 90, 14, 210, 600, 1500, 950, 100, 100, 50, 50, listPosition[17], listOwner[17], (listHouse[17])[1], (listHouse[17])[2], (listHouse[17])[3]));
            listPiece.Add(new ChanceAndCommunityChest(1, listPosition[18]));
            listPiece.Add(new Land(5, 180, 90, 14, 210, 600, 1500, 950, 100, 100, 50, 50, listPosition[19], listOwner[19], (listHouse[19])[1], (listHouse[19])[2], (listHouse[19])[3]));
            listPiece.Add(new Land(5, 200, 100, 16, 240, 660, 1550, 1000, 100, 100, 50, 50, listPosition[20], listOwner[20], (listHouse[20])[1], (listHouse[20])[2], (listHouse[20])[3]));
            listPiece.Add(new RandomTele(listPosition[21]));
            listPiece.Add(new Land(6, 220, 110, 18, 270, 750, 1800, 1050, 150, 150, 75, 75, listPosition[22], listOwner[22], (listHouse[22])[1], (listHouse[22])[2], (listHouse[22])[3]));
            listPiece.Add(new ChanceAndCommunityChest(2, listPosition[23]));
            listPiece.Add(new Land(6, 220, 110, 18, 270, 750, 1800, 1050, 150, 150, 75, 75, listPosition[24], listOwner[24], (listHouse[24])[1], (listHouse[24])[2], (listHouse[24])[3]));
            listPiece.Add(new Land(6, 240, 120, 20, 300, 900, 2000, 1100, 150, 150, 75, 75, listPosition[25], listOwner[25], (listHouse[25])[1], (listHouse[25])[2], (listHouse[25])[3]));
            listPiece.Add(new Station(listOwner[26], listPosition[26], 2, 200, 100, 100));
            listPiece.Add(new Land(7, 260, 130, 22, 330, 990, 2200, 1150, 150, 150, 75, 75, listPosition[27], listOwner[27], (listHouse[27])[1], (listHouse[27])[2], (listHouse[27])[3]));
            listPiece.Add(new Land(7, 260, 130, 22, 330, 990, 2200, 1150, 150, 150, 75, 75, listPosition[28], listOwner[28], (listHouse[28])[1], (listHouse[28])[2], (listHouse[28])[3]));
            listPiece.Add(new Factory(listOwner[29], listPosition[29], 10, 200, 100));
            listPiece.Add(new Land(7, 280, 140, 24, 360, 1180, 2300, 1200, 150, 150, 75, 75, listPosition[30], listOwner[30], (listHouse[30])[1], (listHouse[30])[2], (listHouse[30])[3]));
            listPiece.Add(new GoToJail(listPosition[31]));
            listPiece.Add(new Land(8, 300, 150, 26, 390, 1170, 2500, 1275, 200, 200, 100, 100, listPosition[32], listOwner[32], (listHouse[32])[1], (listHouse[32])[2], (listHouse[32])[3]));
            listPiece.Add(new Land(8, 300, 150, 26, 390, 1170, 2500, 1275, 200, 200, 100, 100, listPosition[33], listOwner[33], (listHouse[33])[1], (listHouse[33])[2], (listHouse[33])[3]));
            listPiece.Add(new ChanceAndCommunityChest(1, listPosition[34]));
            listPiece.Add(new Land(8, 320, 160, 28, 450, 1170, 2600, 1400, 200, 200, 100, 100, listPosition[35], listOwner[35], (listHouse[35])[1], (listHouse[35])[2], (listHouse[35])[3]));
            listPiece.Add(new Station(listOwner[36], listPosition[36], 2, 200, 100, 200));
            listPiece.Add(new ChanceAndCommunityChest(2, listPosition[37]));
            listPiece.Add(new Land(9, 350, 175, 35, 400, 1500, 3000, 1500, 200, 200, 100, 100, listPosition[38], listOwner[38], (listHouse[38])[1], (listHouse[38])[2], (listHouse[38])[3]));
            listPiece.Add(new Tax(listPosition[39], 2));
            listPiece.Add(new Land(9, 360, 180, 35, 400, 1500, 3100, 2000, 200, 200, 100, 100, listPosition[40], listOwner[40], (listHouse[40])[1], (listHouse[40])[2], (listHouse[40])[3]));
            listPiece.Add(new InJail(listPosition[41]));
            _listPiece = listPiece;
        }
        #endregion

        #region Count something
        private int CountAllPersonInJail()
        {
            return (_listPiece[11] as VisitJail).Position.Controls.Count - 1;
        }

        private int CountAllHouseForCurrentPlayer()
        {
            int result = 0;
            foreach (var item in ListPiece)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Type == 1)
                {
                    if ((item as Land).OwnerPlayer == CurrentPlayer)
                    {
                        result += (item as Land).HouseNumber;
                    }
                }
            }
            return result;
        }

        private int CountAllHotelForCurrentPlayer()
        {
            int result = 0;
            foreach (var item in ListPiece)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Type == 1)
                {
                    if ((item as Land).OwnerPlayer == CurrentPlayer)
                    {
                        result += (item as Land).HotelNumber;
                    }
                }
            }
            return result;
        }

        private int CountAllPieceForCurrentPlayer(int type)
        {
            int result = 0;
            foreach (var item in ListPiece)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Type == type)
                {
                    if ((item as Land).OwnerPlayer == CurrentPlayer)
                    {
                        result++;
                    }
                }
            }
            return result;
        }
        #endregion

        #region Do action
        
        private void NextPlayer()
        {
            do
            {
                if (CurrentPlayer < 4)
                {
                    CurrentPlayer++;
                }
                else
                {
                    CurrentPlayer = 1;
                }
            }
            while (!IsAlive(CurrentPlayer));
        }

        private void SellSequenceHouseToHotelToPiece(int priceToPay)
        {
            //Sell House
            while (CountAllHouseForCurrentPlayer() > 0)
            {
                
                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 1)
                    {
                        if ((item as Land).OwnerPlayer == CurrentPlayer && (item as Land).HouseNumber > 0)
                        {
                            bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("You wanna to sell one house of this land for " + (item as Land).HouseMortgage);
                            if (answer == true)
                            {
                                int transMoney = (item as Land).SellHouse();
                                _form.TransMoneyFromBankToPlayer(transMoney);
                                SellHouseGraphic(ListPiece.IndexOf(item));
                                ListPlayer[CurrentPlayer].Money += transMoney;
                                SetAllPlayerGraphic();
                                if (ListPlayer[CurrentPlayer].Money >= priceToPay)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }

            //Sell Hotel
            while (CountAllHotelForCurrentPlayer() > 0)
            {
                
                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 1)
                    {
                        if ((item as Land).OwnerPlayer == CurrentPlayer && (item as Land).HotelNumber > 0)
                        {
                            bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("You wanna to sell hotel of this land for " + (item as Land).HotelMortgage);
                            if (answer == true)
                            {
                                int transMoney = (item as Land).SellHotel();
                                _form.TransMoneyFromBankToPlayer(transMoney);
                                SellHotelGraphic(ListPiece.IndexOf(item));
                                ListPlayer[CurrentPlayer].Money += transMoney;
                                SetAllPlayerGraphic();
                                if (ListPlayer[CurrentPlayer].Money >= priceToPay)
                                {
                                    return;
                                }
                            }

                        }
                    }
                }
            }

            //Sell Piece
            while (CountAllPieceForCurrentPlayer(1) > 0)
            {
                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 1)
                    {
                        if ((item as Land).OwnerPlayer == CurrentPlayer)
                        {
                            bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("You wanna to sell this land for " + (item as Land).Mortgage);
                            if (answer == true)
                            {
                                int transMoney = (item as Land).SellPiece();
                                _form.TransMoneyFromBankToPlayer(transMoney);
                                SellLandGraphic(ListPiece.IndexOf(item));
                                ListPlayer[CurrentPlayer].Money += transMoney;
                                SetAllPlayerGraphic();
                                if (ListPlayer[CurrentPlayer].Money >= priceToPay)
                                {
                                    return;
                                }
                            }

                        }
                    }
                }
            }

            //Sell Factory
            while (CountAllPieceForCurrentPlayer(3) > 0)
            {
                
                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 3)
                    {
                        if ((item as Factory).OwnerPlayer == CurrentPlayer)
                        {
                            bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("You wanna to sell this factory for " + (item as Factory).Mortgage);
                            if (answer == true)
                            {
                                int transMoney = (item as Factory).SellPiece();
                                _form.TransMoneyFromBankToPlayer(transMoney);
                                SellFactoryGraphic(ListPiece.IndexOf(item));
                                ListPlayer[CurrentPlayer].Money += transMoney;
                                SetAllPlayerGraphic();
                                if (ListPlayer[CurrentPlayer].Money >= priceToPay)
                                {
                                    return;
                                }
                            }

                        }
                    }
                }
            }

            //Sell Station
            while (CountAllPieceForCurrentPlayer(2) > 0)
            {         
                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 2)
                    {
                        if ((item as Station).OwnerPlayer == CurrentPlayer)
                        {
                            bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("You wanna to sell this station for " + (item as Station).Mortgage);
                            if (answer == true)
                            {
                                int transMoney = (item as Station).SellPiece();
                                _form.TransMoneyFromBankToPlayer(transMoney);
                                SellStationGraphic(ListPiece.IndexOf(item));
                                ListPlayer[CurrentPlayer].Money += transMoney;
                                SetAllPlayerGraphic();
                                if (ListPlayer[CurrentPlayer].Money >= priceToPay)
                                {
                                    return;
                                }
                            }

                        }
                    }
                }
            }
        }

        private int CheckMoneyToDoSomething()
        {
            int totalMoney = ListPlayer[CurrentPlayer].Money;
            foreach (Piece item in ListPiece)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Type == 1)
                {
                    Land tempLand = (item as Land);
                    if (tempLand.OwnerPlayer == CurrentPlayer)
                    {
                        totalMoney += tempLand.Mortgage + tempLand.HotelNumber * tempLand.HouseMortgage + tempLand.HotelMortgage;
                    }
                }
                else if (item.Type == 2)
                {
                    Station tempLand = (item as Station);
                    if (tempLand.OwnerPlayer == CurrentPlayer)
                    {
                        totalMoney += tempLand.Mortgage;
                    }
                }
                else if (item.Type == 3)
                {
                    Factory tempLand = (item as Factory);
                    if (tempLand.OwnerPlayer == CurrentPlayer)
                    {
                        totalMoney += tempLand.Mortgage;
                    }
                }
            }
            return totalMoney;
        }

        private void SendMoneyToEachOther(int money)
        {
            foreach (var item in ListPlayer)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.Name != ListPlayer[CurrentPlayer].Name)
                {
                    _form.TransMoneyToPlayer(money, ListPlayer.IndexOf(item));
                    item.Money += money;
                    _form.AllPlayerGraphicSet();
                }
            }
        }
        #endregion

        #region Action at piece

        #region Chance Chest Card Action
        private void ChestCard1()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = 50;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                }
            }
        }

        private void ChestCard2()
        {
            ListPiece[41].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
            ListPlayer[CurrentPlayer].CurrentPosition = 41;
            ListPlayer[CurrentPlayer].RollCounter = 0;
        }

        private void ChestCard3()
        {
            MessageBox.Show("Try Again :))");
        }

        private void ChestCard4()
        {
            _form.TransMoneyFromBankToPlayer(150);
            ListPlayer[CurrentPlayer].Money += 150;
            _form.AllPlayerGraphicSet();
        }

        private void ChestCard5()
        {
            _form.TransMoneyFromBankToPlayer(100);
            ListPlayer[CurrentPlayer].Money += 100;
            _form.AllPlayerGraphicSet();
        }

        private void ChestCard6()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = 50;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                }
            }
        }

        private void ChestCard7()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = 50;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                }
            }
        }

        private void ChestCard8()
        {
            _form.TransMoneyFromBankToPlayer(200);
            ListPlayer[CurrentPlayer].Money += 200;
            _form.AllPlayerGraphicSet();
        }

        private void ChestCard9()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = CountAllHouseForCurrentPlayer() * 40 + CountAllHotelForCurrentPlayer() * 115;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                }
            }
        }

        private void ChestCard10()
        {
            _form.TransMoneyFromBankToPlayer(100);
            ListPlayer[CurrentPlayer].Money += 100;
            _form.AllPlayerGraphicSet();
        }

        private void ChanceCard1()
        {
            ListPiece[1].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
            ListPlayer[CurrentPlayer].Move(1);
        }

        private void ChanceCard2()
        {
            int nearestUtinity = 1;
            switch (ListPlayer[CurrentPlayer].CurrentPosition)
            {
                case 8:
                    nearestUtinity = 13;
                    break;
                default:
                    nearestUtinity = 29;
                    break;
            }
            ListPiece[nearestUtinity].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
            ListPlayer[CurrentPlayer].CurrentPosition = nearestUtinity;
            ActionOnFactoryForChance(ListPlayer[CurrentPlayer].CurrentPosition, 10);
        }

        private void ChanceCard3()
        {
            int nearestStation = 26;
            switch (ListPlayer[CurrentPlayer].CurrentPosition)
            {
                case 8:
                    nearestStation = 6;
                    break;
                case 23:
                    nearestStation = 26;
                    break;
                default:
                    nearestStation = 36;
                    break;
            }
            ListPiece[nearestStation].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
            ListPlayer[CurrentPlayer].CurrentPosition = nearestStation;
            ActionOnStationForChance(ListPlayer[CurrentPlayer].CurrentPosition);
        }

        private void ChanceCard4()
        {
            ListPlayer[CurrentPlayer].PrisonBreak++;
            SetAllPlayerGraphic();
        }

        private void ChanceCard5()
        {
            ListPiece[CurrentPlayer - 3].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
            ListPlayer[CurrentPlayer].CurrentPosition -= 3;
            switch (ListPlayer[CurrentPlayer].CurrentPosition)
            {
                case 5:
                    ActionOnTax(5);
                    break;
                case 20:
                    ActionOnLand(20);
                    break;
                case 34:
                    ActionOnChanceAndChest(34);
                    break;
                default:
                    break;
            }
            SetAllPlayerGraphic();
        }

        private void ChanceCard6()
        {
            ListPiece[41].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
            ListPlayer[CurrentPlayer].CurrentPosition = 41;
            ListPlayer[CurrentPlayer].RollCounter = 0;
        }

        private void ChanceCard7()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = CountAllHouseForCurrentPlayer() * 25 + CountAllHotelForCurrentPlayer() * 100;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(totalMoney);
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                    _form.AllPlayerGraphicSet();
                }
            }
        }

        private void ChanceCard8()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = 15;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(totalMoney);
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                    _form.AllPlayerGraphicSet();
                }
            }
        }

        private void ChanceCard9()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = 150;
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                SendMoneyToEachOther(50);
                _form.AllPlayerGraphicSet();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    SendMoneyToEachOther(50);
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    int money = totalMoney / 3 + 1;
                    SendMoneyToEachOther(money);
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                    _form.AllPlayerGraphicSet();
                }
            }
        }

        private void ChanceCard10()
        {
            _form.TransMoneyFromBankToPlayer(100);
            ListPlayer[CurrentPlayer].Money += 100;
        }
        #endregion

        private void ActionAtPiece(int currentPoint)
        {
            switch (ListPiece[currentPoint].Type)
            {
                case 0:
                    //Do notthing
                    break;
                case 1:
                    ActionOnLand(currentPoint);
                    break;
                case 2:
                    ActionOnStation(currentPoint);
                    break;
                case 3:
                    ActionOnFactory(currentPoint);
                    break;
                case 4:
                    ActionOnTax(currentPoint);
                    break;
                case 5:
                    ActionOnRandomTele();
                    break;
                case 7:
                    ActionInJail();
                    break;
                case 8:
                    ActionOnVisitJail();
                    break;
                case 9:
                    ActionOnChanceAndChest(currentPoint);
                    break;
                default:
                    break;
            }
        }

        private void ActionOnChanceAndChest(int currentPoint)
        {
            int typeOfPiece = (ListPiece[currentPoint] as ChanceAndCommunityChest).Side;
            if (typeOfPiece == 1) //Chance
            {
                int result = (ListPiece[currentPoint] as ChanceAndCommunityChest).ChanceAction();
                switch (result)
                {
                    case 1:
                        ChanceCard1();
                        break;
                    case 2:
                        ChanceCard2();
                        break;
                    case 3:
                        ChanceCard3();
                        break;
                    case 4:
                        ChanceCard4();
                        break;
                    case 5:
                        ChanceCard5();
                        break;
                    case 6:
                        ChanceCard6();
                        break;
                    case 7:
                        ChanceCard7();
                        break;
                    case 8:
                        ChanceCard8();
                        break;
                    case 9:
                        ChanceCard9();
                        break;
                    case 10:
                        ChanceCard10();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                int result = (ListPiece[currentPoint] as ChanceAndCommunityChest).ChestAction();
                switch (result)
                {
                    case 1:
                        ChestCard1();
                        break;
                    case 2:
                        ChestCard2();
                        break;
                    case 3:
                        ChestCard3();
                        break;
                    case 4:
                        ChestCard4();
                        break;
                    case 5:
                        ChestCard5();
                        break;
                    case 6:
                        ChestCard6();
                        break;
                    case 7:
                        ChestCard7();
                        break;
                    case 8:
                        ChestCard8();
                        break;
                    case 9:
                        ChestCard9();
                        break;
                    case 10:
                        ChestCard10();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ActionOnVisitJail()
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = (ListPiece[11] as VisitJail).VisitFee(CountAllPersonInJail());
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                SetAllPlayerGraphic();
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    SetAllPlayerGraphic();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(totalMoney);
                    ListPlayer[CurrentPlayer].Money = 0;
                    SetAllPlayerGraphic();
                }
            }
        }

        private void ActionInJail()
        {
            int costMustPay = (ListPiece[41] as InJail).JailFee();
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to free with 500 ?");
                if (answer)
                {
                    ListPlayer[CurrentPlayer].PayForFree();
                    _form.TransMoneyToBank(costMustPay);
                    ListPiece[11].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                    SetAllPlayerGraphic();
                }
                return;
            }
        }

        private void ActionOnRandomTele()
        {
            _listPlayer[CurrentPlayer].CurrentPosition = (ListPiece[21] as RandomTele).RandomPosition();
            _listPlayer[CurrentPlayer].RollCounter = 0;
            ListPiece[_listPlayer[CurrentPlayer].CurrentPosition].Position.Controls.Add(_listPlayer[CurrentPlayer].PlayerToken);
            ActionAtPiece(_listPlayer[CurrentPlayer].CurrentPosition);
        }

        private void ActionOnTax(int currentPoint)
        {
            int totalMoney = CheckMoneyToDoSomething();
            int costMustPay = (ListPiece[currentPoint] as Tax).CostForVisitor(ListPlayer[CurrentPlayer].Money);
            if (ListPlayer[CurrentPlayer].Money >= costMustPay)
            {
                _form.TransMoneyToBank(costMustPay);
                ListPlayer[CurrentPlayer].Money -= costMustPay;
                _form.AllPlayerGraphicSet();
                return;
            }
            else
            {
                if (totalMoney >= costMustPay)
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(costMustPay);
                    ListPlayer[CurrentPlayer].Money -= costMustPay;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    SellSequenceHouseToHotelToPiece(costMustPay);
                    _form.TransMoneyToBank(totalMoney);
                    ListPlayer[CurrentPlayer].Money -= totalMoney;
                    ListPlayer[CurrentPlayer].IsALive = false;
                    ShowInfoDeadPlayer();
                    _form.AllPlayerGraphicSet();
                }
            }
        }

        private void ActionOnFactory(int currentPoint)
        {
            int totalMoney = CheckMoneyToDoSomething();
            if ((ListPiece[currentPoint] as Factory).OwnerPlayer == 0)
            {
                // Gạ mua
                bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy this Place ?");
                if (answer == true)
                {
                    if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Factory).Price)
                    {
                        BuyFactoryGraphic(currentPoint);
                        int moneyAfterBuy = (ListPiece[currentPoint] as Factory).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                        ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                        SetAllPlayerGraphic();
                    }
                    else
                    {
                        bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                        if (sellPieceAnswer == true)
                        {
                            if (totalMoney >= (ListPiece[currentPoint] as Factory).Price)
                            {
                                SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Factory).Price);
                                BuyFactoryGraphic(currentPoint);
                                int moneyAfterBuy = (ListPiece[currentPoint] as Factory).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                                ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                SetAllPlayerGraphic();
                            }
                            else
                            {
                                ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                            }
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            else if ((ListPiece[currentPoint] as Factory).OwnerPlayer != CurrentPlayer)
            {
                int ownerPiecePlayer = (ListPiece[currentPoint] as Factory).OwnerPlayer;
                int groupID = (ListPiece[currentPoint] as Factory).Group;
                int groupCount = 0;

                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 3)
                    {
                        if ((item as Factory).Group == groupID && (item as Factory).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    if (groupCount >= 2)
                    {
                        break;
                    }
                }

                Tuple<int, int> costMustPay = (ListPiece[currentPoint] as Factory).CostForVisitor(ListPlayer[CurrentPlayer].Dice1 + ListPlayer[CurrentPlayer].Dice2, groupCount);
                if (ListPlayer[CurrentPlayer].Money >= costMustPay.Item2)
                {
                    _form.TransMoneyToPlayer(costMustPay.Item2, costMustPay.Item1);
                    ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                    ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                    _form.AllPlayerGraphicSet();
                    return;
                }
                else
                {
                    if (totalMoney >= costMustPay.Item2)
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2);
                        _form.TransMoneyToPlayer(costMustPay.Item2, costMustPay.Item1);
                        ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                        ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                        _form.AllPlayerGraphicSet();
                    }
                    else
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2);
                        _form.TransMoneyToPlayer(totalMoney, costMustPay.Item1);
                        ListPlayer[costMustPay.Item1].Money += totalMoney;
                        ListPlayer[CurrentPlayer].IsALive = false;
                        ShowInfoDeadPlayer();
                        _form.AllPlayerGraphicSet();
                    }
                }
            }
        }

        private void ActionOnFactoryForChance(int currentPoint, int xFee)
        {
            int totalMoney = CheckMoneyToDoSomething();
            if ((ListPiece[currentPoint] as Factory).OwnerPlayer == 0)
            {
                // Gạ mua
                bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy this Place ?");
                if (answer == true)
                {
                    if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Factory).Price)
                    {
                        BuyFactoryGraphic(currentPoint);
                        int moneyAfterBuy = (ListPiece[currentPoint] as Factory).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                        ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                        SetAllPlayerGraphic();
                    }
                    else
                    {
                        bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                        if (sellPieceAnswer == true)
                        {
                            if (totalMoney >= (ListPiece[currentPoint] as Factory).Price)
                            {
                                SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Factory).Price);
                                BuyFactoryGraphic(currentPoint);
                                int moneyAfterBuy = (ListPiece[currentPoint] as Factory).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                                ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                SetAllPlayerGraphic();
                            }
                            else
                            {
                                ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                            }
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            else if ((ListPiece[currentPoint] as Factory).OwnerPlayer != CurrentPlayer)
            {
                int ownerPiecePlayer = (ListPiece[currentPoint] as Factory).OwnerPlayer;
                int groupID = (ListPiece[currentPoint] as Factory).Group;
                int groupCount = 0;

                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 3)
                    {
                        if ((item as Factory).Group == groupID && (item as Factory).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    if (groupCount >= 2)
                    {
                        break;
                    }
                }

                Tuple<int, int> costMustPay = (ListPiece[currentPoint] as Factory).CostForVisitor(ListPlayer[CurrentPlayer].Dice1 + ListPlayer[CurrentPlayer].Dice2, groupCount);
                if (ListPlayer[CurrentPlayer].Money >= costMustPay.Item2 * xFee)
                {
                    _form.TransMoneyToPlayer(costMustPay.Item2 * xFee, costMustPay.Item1);
                    ListPlayer[CurrentPlayer].Money -= costMustPay.Item2 * xFee;
                    ListPlayer[costMustPay.Item1].Money += costMustPay.Item2 * xFee;
                    _form.AllPlayerGraphicSet();
                    return;
                }
                else
                {
                    if (totalMoney >= costMustPay.Item2 * xFee)
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2 * xFee);
                        _form.TransMoneyToPlayer(costMustPay.Item2 * xFee, costMustPay.Item1);
                        ListPlayer[CurrentPlayer].Money -= costMustPay.Item2 * xFee;
                        ListPlayer[costMustPay.Item1].Money += costMustPay.Item2 * xFee;
                        _form.AllPlayerGraphicSet();
                    }
                    else
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2 * xFee);
                        _form.TransMoneyToPlayer(totalMoney, costMustPay.Item1);
                        ListPlayer[costMustPay.Item1].Money += totalMoney;
                        ListPlayer[CurrentPlayer].IsALive = false;
                        ShowInfoDeadPlayer();
                        _form.AllPlayerGraphicSet();
                    }
                }
            }
        }

        private void ActionOnStation(int currentPoint)
        {
            int totalMoney = CheckMoneyToDoSomething();
            if ((ListPiece[currentPoint] as Station).OwnerPlayer == 0)
            {
                // Gạ mua
                bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy this Place ?");
                if (answer == true)
                {
                    if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Station).Price)
                    {
                        BuyStationGraphic(currentPoint);
                        int moneyAfterBuy = (ListPiece[currentPoint] as Station).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                        _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                        ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                        SetAllPlayerGraphic();
                    }
                    else
                    {
                        bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                        if (sellPieceAnswer == true)
                        {
                            if (totalMoney >= (ListPiece[currentPoint] as Station).Price)
                            {
                                SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Station).Price);
                                BuyStationGraphic(currentPoint);
                                int moneyAfterBuy = (ListPiece[currentPoint] as Station).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                                _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                                ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                SetAllPlayerGraphic();
                            }
                            else
                            {
                                ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                            }
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            else if ((ListPiece[currentPoint] as Station).OwnerPlayer != CurrentPlayer)
            {
                int ownerPiecePlayer = (ListPiece[currentPoint] as Station).OwnerPlayer;
                int groupID = (ListPiece[currentPoint] as Station).Group;
                int groupCount = 0;

                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 2)
                    {
                        if ((item as Station).Group == groupID && (item as Station).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    if (groupCount >= 4)
                    {
                        break;
                    }
                }

                Tuple<int, int> costMustPay = (ListPiece[currentPoint] as Station).CostForVisitor(groupCount);
                if (ListPlayer[CurrentPlayer].Money >= costMustPay.Item2)
                {
                    _form.TransMoneyToPlayer(costMustPay.Item2, costMustPay.Item1);
                    ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                    ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                    _form.AllPlayerGraphicSet();
                    return;
                }
                else
                {
                    if (totalMoney >= costMustPay.Item2)
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2);
                        _form.TransMoneyToPlayer(costMustPay.Item2, costMustPay.Item1);
                        ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                        ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                        _form.AllPlayerGraphicSet();
                    }
                    else
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2);
                        _form.TransMoneyToPlayer(totalMoney, costMustPay.Item1);
                        ListPlayer[costMustPay.Item1].Money += totalMoney;
                        ListPlayer[CurrentPlayer].IsALive = false;
                        ShowInfoDeadPlayer();
                        _form.AllPlayerGraphicSet();
                    }
                }
            }
        }

        private void ActionOnStationForChance(int currentPoint)
        {
            int totalMoney = CheckMoneyToDoSomething();
            if ((ListPiece[currentPoint] as Station).OwnerPlayer == 0)
            {
                // Gạ mua
                bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy this Place ?");
                if (answer == true)
                {
                    if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Station).Price)
                    {
                        BuyStationGraphic(currentPoint);
                        int moneyAfterBuy = (ListPiece[currentPoint] as Station).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                        _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                        ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                        SetAllPlayerGraphic();
                    }
                    else
                    {
                        bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                        if (sellPieceAnswer == true)
                        {
                            if (totalMoney >= (ListPiece[currentPoint] as Station).Price)
                            {
                                SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Station).Price);
                                BuyStationGraphic(currentPoint);
                                int moneyAfterBuy = (ListPiece[currentPoint] as Station).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                                _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                                ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                SetAllPlayerGraphic();
                            }
                            else
                            {
                                ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                            }
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            else if ((ListPiece[currentPoint] as Station).OwnerPlayer != CurrentPlayer)
            {
                int ownerPiecePlayer = (ListPiece[currentPoint] as Station).OwnerPlayer;
                int groupID = (ListPiece[currentPoint] as Station).Group;
                int groupCount = 0;

                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 2)
                    {
                        if ((item as Station).Group == groupID && (item as Station).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    if (groupCount >= 4)
                    {
                        break;
                    }
                }

                Tuple<int, int> costMustPay = (ListPiece[currentPoint] as Station).CostForVisitor(groupCount);
                if (ListPlayer[CurrentPlayer].Money >= costMustPay.Item2)
                {
                    _form.TransMoneyToPlayer(costMustPay.Item2, costMustPay.Item1);
                    ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                    ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                    _form.AllPlayerGraphicSet();
                    return;
                }
                else
                {
                    if (totalMoney >= costMustPay.Item2 * 2)
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2 * 2);
                        _form.TransMoneyToPlayer(costMustPay.Item2 * 2, costMustPay.Item1);
                        ListPlayer[CurrentPlayer].Money -= costMustPay.Item2 * 2;
                        ListPlayer[costMustPay.Item1].Money += costMustPay.Item2 * 2;
                        _form.AllPlayerGraphicSet();
                    }
                    else
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2 * 2);
                        _form.TransMoneyToPlayer(totalMoney, costMustPay.Item1);
                        ListPlayer[costMustPay.Item1].Money += totalMoney;
                        ListPlayer[CurrentPlayer].IsALive = false;
                        ShowInfoDeadPlayer();
                        _form.AllPlayerGraphicSet();
                    }
                }
            }
        }
        
        private void ActionOnLand(int currentPoint)
        {
            int totalMoney = CheckMoneyToDoSomething();
            if ((ListPiece[currentPoint] as Land).OwnerPlayer == 0)
            {
                // Gạ mua
                bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy this Place ?");
                if (answer == true)
                {
                    if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Land).Price)
                    {
                        int moneyAfterBuy = (ListPiece[currentPoint] as Land).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                        _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                        BuyLandGraphic(currentPoint);
                        ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                        SetAllPlayerGraphic();
                    }
                    else
                    {
                        bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                        if (sellPieceAnswer == true)
                        {
                            if (totalMoney >= (ListPiece[currentPoint] as Land).Price)
                            {

                                SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Land).Price);
                                int moneyAfterBuy = (ListPiece[currentPoint] as Land).BuyPiece(CurrentPlayer, ListPlayer[CurrentPlayer].Money);
                                _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                                BuyLandGraphic(currentPoint);
                                ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                SetAllPlayerGraphic();
                            }
                            else
                            {
                                ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                            }
                        }
                    }
                    return;
                }
                else
                {
                    return;
                }
            }
            else if ((ListPiece[currentPoint] as Land).OwnerPlayer == CurrentPlayer)
            {
                if ((ListPiece[currentPoint] as Land).HouseNumber < 3)
                {
                    // Gạ mua
                    bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy house for this Place ?");
                    if (answer == true)
                    {
                        if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Land).HousePrice)
                        {
                            int moneyAfterBuy = (ListPiece[currentPoint] as Land).BuyHouse(ListPlayer[CurrentPlayer].Money);
                            _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                            BuyHouseGraphic(currentPoint);
                            ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                            SetAllPlayerGraphic();
                        }
                        else
                        {
                            bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                            if (sellPieceAnswer == true)
                            {
                                if (totalMoney >= (ListPiece[currentPoint] as Land).HousePrice)
                                {
                                    SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Land).HousePrice);
                                    int moneyAfterBuy = (ListPiece[currentPoint] as Land).BuyHouse(ListPlayer[CurrentPlayer].Money);
                                    _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                                    BuyHouseGraphic(currentPoint);
                                    ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                    SetAllPlayerGraphic();
                                }
                                else
                                {
                                    ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                                }
                            }
                        }
                        return;
                    }
                }
                else if ((ListPiece[currentPoint] as Land).HotelNumber < 1)
                {
                    // Gạ mua
                    bool answer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to buy hotel for this Place ?");
                    if (answer == true)
                    {
                        if (ListPlayer[CurrentPlayer].Money >= (ListPiece[currentPoint] as Land).HotelPrice)
                        {
                            int moneyAfterBuy = (ListPiece[currentPoint] as Land).BuyHotel(ListPlayer[CurrentPlayer].Money);
                            _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                            BuyHotelGraphic(currentPoint);
                            ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                            SetAllPlayerGraphic();
                        }
                        else
                        {
                            bool sellPieceAnswer = ListPlayer[CurrentPlayer].YesNoQuestion("Want to mortage some house, hotel, land,... to Buy it?");
                            if (sellPieceAnswer == true)
                            {
                                if (totalMoney >= (ListPiece[currentPoint] as Land).HotelPrice)
                                {
                                    SellSequenceHouseToHotelToPiece((ListPiece[currentPoint] as Land).HotelPrice);
                                    int moneyAfterBuy = (ListPiece[currentPoint] as Land).BuyHotel(ListPlayer[CurrentPlayer].Money);
                                    _form.TransMoneyToBank(ListPlayer[CurrentPlayer].Money - moneyAfterBuy);
                                    BuyHotelGraphic(currentPoint);
                                    ListPlayer[CurrentPlayer].Money = moneyAfterBuy;
                                    SetAllPlayerGraphic();
                                }
                                else
                                {
                                    ListPlayer[CurrentPlayer].YesNoQuestion("Có mua thì mới có ăn, không đủ tiền mua mà muốn ăn thì ... =))");
                                }
                            }
                        }
                        return;
                    }
                }
            }
            else
            {
                int ownerPiecePlayer = (ListPiece[currentPoint] as Land).OwnerPlayer;
                int groupID = (ListPiece[currentPoint] as Land).Group;
                int groupCount = 0;

                foreach (var item in ListPiece)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.Type == 1)
                    {
                        if ((item as Land).Group == groupID && (item as Land).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    else if (item.Type == 2)
                    {
                        if ((item as Station).Group == groupID && (item as Station).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    else if (item.Type == 3)
                    {
                        if ((item as Factory).Group == groupID && (item as Factory).OwnerPlayer == ownerPiecePlayer)
                        {
                            groupCount++;
                        }
                    }
                    if (groupCount >= 3)
                    {
                        break;
                    }
                }

                Tuple<int, int> costMustPay = (ListPiece[currentPoint] as Land).CostForVisitor(groupCount);
                if (ListPlayer[CurrentPlayer].Money >= costMustPay.Item2)
                {
                    _form.TransMoneyToPlayer(costMustPay.Item2, costMustPay.Item1);
                    ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                    ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                    _form.AllPlayerGraphicSet();
                }
                else
                {
                    if (totalMoney >= costMustPay.Item2)
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2);
                        _form.TransMoneyToPlayer(totalMoney, costMustPay.Item1);
                        ListPlayer[CurrentPlayer].Money -= costMustPay.Item2;
                        ListPlayer[costMustPay.Item1].Money += costMustPay.Item2;
                        _form.AllPlayerGraphicSet();
                    }
                    else
                    {
                        SellSequenceHouseToHotelToPiece(costMustPay.Item2);
                        _form.TransMoneyToPlayer(totalMoney, costMustPay.Item1);
                        ListPlayer[costMustPay.Item1].Money += totalMoney;
                        ListPlayer[CurrentPlayer].IsALive = false;
                        ShowInfoDeadPlayer();
                        _form.AllPlayerGraphicSet();
                    }
                }
            }
        }
        #endregion

        #region Command use

        public void MoveForMainPlayer()
        {
            SetCurrentPlayer();
        RollAgain:
            SetAllPlayerGraphic();

            Tuple<int, int> diceResult = _listPlayer[CurrentPlayer].Roll();
            int startAt = _listPlayer[CurrentPlayer].CurrentPosition;
            int endAt = _listPlayer[CurrentPlayer].Move();

            SetDiceResult();
            SetAllPlayerGraphic();
            //Vô tù time
            if (endAt == 41 || diceResult == null)
            {
                for (int i = startAt; i <= 31; i++)
                {
                    ListPiece[i].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                    Task sleepTask = new Task(Sleep);
                    sleepTask.Start();
                    sleepTask.Wait();
                }
                ListPiece[41].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                ListPlayer[CurrentPlayer].RollCounter = 0;
            }

            //Nếu ở ngoài tù
            else if (endAt > 0)
            {
                Task rollTask = new Task(_form.StartPlayerRoll);
                rollTask.Start();
                rollTask.Wait();

                while (startAt != endAt + 1)
                {
                    ListPiece[startAt].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                    Task sleepTask = new Task(Sleep);
                    sleepTask.Start();
                    sleepTask.Wait();
                    if (startAt == 40)
                    {
                        startAt = 1;
                    }
                    else
                    {
                        startAt++;
                    }
                }

                int currentPoint = _listPlayer[CurrentPlayer].CurrentPosition;
                ActionAtPiece(currentPoint);
            }

            //Nếu đang trong tù
            else if (diceResult != null)
            {
                if (_listPlayer[CurrentPlayer].PrisonBreak > 0)
                {
                    bool questionResult = _listPlayer[CurrentPlayer].YesNoQuestion("Do you want to use break card?");
                    if (questionResult == true)
                    {
                        _listPlayer[CurrentPlayer].GetFree();
                        ListPiece[11].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                        SetAllPlayerGraphic();
                    }
                    else
                    {
                        bool questionResult1 = _listPlayer[CurrentPlayer].YesNoQuestion("Do you want to free by Pay 500?");
                        if (questionResult1 == true)
                        {
                            _listPlayer[CurrentPlayer].PayForFree();
                            _form.TransMoneyToBank(500);
                            ListPiece[11].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                            SetAllPlayerGraphic();
                        }
                    }
                }
                else if (_listPlayer[CurrentPlayer].Money >= 500)
                {
                    bool questionResult = _listPlayer[CurrentPlayer].YesNoQuestion("Do you want to free by Pay 500?");
                    if (questionResult == true)
                    {
                        _listPlayer[CurrentPlayer].PayForFree();
                        _form.TransMoneyToBank(500);
                        ListPiece[11].Position.Controls.Add(ListPlayer[CurrentPlayer].PlayerToken);
                        SetAllPlayerGraphic();
                    }
                }
                else
                {
                    _listPlayer[CurrentPlayer].YesNoQuestion("You don't have enough money to get free");
                }
            }

            //Nếu đủ điều kiện đi tiếp vì đổ ra đôi thì cho đổ tiếp 
            if (_listPlayer[CurrentPlayer].RollCounter < 3 && _listPlayer[CurrentPlayer].RollCounter > 0 && diceResult != null && ListPlayer[CurrentPlayer].CurrentPosition != 41)
            {
                goto RollAgain;
            }

            //Nếu kq của lượt đi trước là 41 thì dù có đổ ra đôi cũng vô nghĩa và kết thúc lượt ngay lập tức
            else if (ListPlayer[CurrentPlayer].CurrentPosition == 41 && _listPlayer[CurrentPlayer].RollCounter > 0)
            {
                ListPlayer[CurrentPlayer].RollCounter = 0;
            }
            NextPlayer();
            SetCurrentPlayer();
        }
        private async void Sleep()
        {
            Thread.Sleep(300);
        }
        public bool IsEndGame()
        {
            int count = 0;
            foreach (var item in ListPlayer)
            {
                if (item == null)
                {
                    continue;
                }
                if (item.IsALive)
                {
                    count++;
                }
            }
            if (count == 1)
            {
                frm_Map.isEndGame = true;
                foreach (var item in ListPlayer)
                {
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.IsALive)
                    {
                        frm_Map.winnerPlayer = ListPlayer.IndexOf(item);
                        break;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsAlive(int player)
        {
            return ListPlayer[player].IsALive;
        }
        public void SetDiceResult()
        {
            frm_Map.diceResult1 = ListPlayer[CurrentPlayer].Dice1;
            frm_Map.diceResult2 = ListPlayer[CurrentPlayer].Dice2;
        }
        public void SetCurrentPlayer()
        {
            frm_Map.currentPlayer = CurrentPlayer;
        }
        public void SetListPiece()
        {
            frm_Map.ListPiece = ListPiece;
        }
        public void SetListPlayer()
        {
            frm_Map.ListPlayer = ListPlayer;
        }
        public void SetAllPlayerGraphic()
        {
            _form.AllPlayerGraphicSet();
        }
        public void BuyLandGraphic(int position)
        {
            switch (CurrentPlayer)
            {
                case 1:
                    (ListPiece[position] as Land).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "blueHouse.png"));
                    break;
                case 2:
                    (ListPiece[position] as Land).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "redHouse.png"));
                    break;
                case 3:
                    (ListPiece[position] as Land).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "yellowHouse.png"));
                    break;
                default:
                    (ListPiece[position] as Land).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "whiteHouse.png"));
                    break;
            }
            
        }
        public void BuyStationGraphic(int position)
        {
            switch (CurrentPlayer)
            {
                case 1:
                    (ListPiece[position] as Station).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "blueHouse.png"));
                    break;
                case 2:
                    (ListPiece[position] as Station).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "redHouse.png"));
                    break;
                case 3:
                    (ListPiece[position] as Station).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "yellowHouse.png"));
                    break;
                default:
                    (ListPiece[position] as Station).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "whiteHouse.png"));
                    break;
            }
        }
        public void BuyFactoryGraphic(int position)
        {
            switch (CurrentPlayer)
            {
                case 1:
                    (ListPiece[position] as Factory).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "blueHouse.png"));
                    break;
                case 2:
                    (ListPiece[position] as Factory).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "redHouse.png"));
                    break;
                case 3:
                    (ListPiece[position] as Factory).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "yellowHouse.png"));
                    break;
                default:
                    (ListPiece[position] as Factory).Owner.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "whiteHouse.png"));
                    break;
            }
        }
        public void SellLandGraphic(int position)
        {
            (ListPiece[position] as Land).Owner.BackgroundImage = null;
        }
        public void SellStationGraphic(int position)
        {
            (ListPiece[position] as Station).Owner.BackgroundImage = null;
        }
        public void SellFactoryGraphic(int position)
        {
            (ListPiece[position] as Factory).Owner.BackgroundImage = null;
        }
        public void BuyHouseGraphic(int position)
        {
            string color = "";
            switch (CurrentPlayer)
            {
                case 1:
                    color = "blueHouse.png";
                    break;
                case 2:
                    color = "redHouse.png";
                    break;
                case 3:
                    color = "yellowHouse.png";
                    break;
                case 4:
                    color = "whiteHouse.png";
                    break;
            }
            switch ((ListPiece[position] as Land).HouseNumber)
            {
                case 1:
                    (ListPiece[position] as Land).House1.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", color));
                    break;
                case 2:
                    (ListPiece[position] as Land).House2.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", color));
                    break;
                case 3:
                    (ListPiece[position] as Land).House3.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", color));
                    break;
            }
        }
        public void BuyHotelGraphic(int position)
        {
            (ListPiece[position] as Land).House1.BackgroundImage = (ListPiece[position] as Land).House2.BackgroundImage
                = (ListPiece[position] as Land).House3.BackgroundImage = null;
            (ListPiece[position] as Land).House1.BackgroundImage = (ListPiece[position] as Land).House2.BackgroundImage
                = (ListPiece[position] as Land).House3.BackgroundImage = new Bitmap(Path.Combine(Application.StartupPath, @"Images", "House", "hotel.png"));
        }
        public void SellHouseGraphic(int position)
        {
            switch ((ListPiece[position] as Land).HouseNumber)
            {
                case 2:
                    (ListPiece[position] as Land).House3.BackgroundImage = null;
                    break;
                case 1:
                    (ListPiece[position] as Land).House2.BackgroundImage = null;
                    break;
                case 0:
                    (ListPiece[position] as Land).House1.BackgroundImage = null;
                    break;
            }
        }
        public void SellHotelGraphic(int position)
        {
            (ListPiece[position] as Land).House1.BackgroundImage = (ListPiece[position] as Land).House2.BackgroundImage
                = (ListPiece[position] as Land).House3.BackgroundImage = null;
        }
        public void ShowInfoDeadPlayer()
        {
            MessageBox.Show("You are Lose !!");
        }
        #endregion
    }
}
