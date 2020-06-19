using MidtermProjectGroup11.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidtermProjectGroup11.GamePlay
{
    public class Player
    {

        #region Properties

        private string _name = "";
        private int _money = 1000;
        private int _prisonBreak = 0;
        private int _prisonTimeCount = 0;
        private bool _isALive = true;
        private int _rollCounter = 0;
        private int _currentPosition = 1;
        private int _dice1, _dice2;
        private PictureBox _playerToken;
        private Color _color;
        
        #endregion

        #region Getter Setter
        public string Name { get => _name; set => _name = value; }
        public int Money { get => _money; set => _money = value; }
        public int PrisonBreak { get => _prisonBreak; set => _prisonBreak = value; }
        public bool IsALive { get => _isALive; set => _isALive = value; }
        public int RollCounter { get => _rollCounter; set => _rollCounter = value; }
        public int CurrentPosition { get => _currentPosition; set => _currentPosition = value; }
        public PictureBox PlayerToken { get => _playerToken; }
        public Color Color { get => _color; }
        public int Dice1 { get => _dice1; }
        public int Dice2 { get => _dice2; }
        public int PrisonTimeCount { get => _prisonTimeCount; set => _prisonTimeCount = value; }
        #endregion

        #region Constructor
        public Player(string name, Color color, PictureBox playerToken)
        {
            _name = name;
            _playerToken = playerToken;
        }
        #endregion

        #region Method
        public Tuple<int, int> Roll()
        {
            _dice1 = RandomTool.Instance.Rand(1, 13);
            _dice2 = RandomTool.Instance.Rand(1, 13);
            if (_dice1 == _dice2)
            {
                RollCounter++;
            }
            else if (RollCounter >= 3)
            {
                RollCounter = 0;
                return null;
            }
            else
            {
                RollCounter = 0;
            }
            return new Tuple<int, int>(_dice1, _dice2);
        }

        public int Move()
        {
            int dice1 = _dice1;
            int dice2 = _dice2;

            if (_currentPosition == 41)
            {
                if (dice1 == dice2)
                {
                    _prisonTimeCount = 0;
                    Transport(11);
                    return 11;
                }
                else if (_prisonTimeCount >= 3)
                {
                    _prisonTimeCount = 0;
                    Transport(11);
                    return 11;
                }
                else
                {
                    PrisonTimeCount++;
                    return 0;
                }
            }

            if (_currentPosition + dice1 + dice2 > 40)
            {
                int passTheGoPiece = 40 - _currentPosition;
                Transport(dice1 + dice2 - passTheGoPiece);
                if (_currentPosition > 1)
                {
                    GetSalaryToPassTheGo();
                    return _currentPosition;
                }
                else
                {
                    return _currentPosition;
                }
            }
            else
            {
                Transport(_currentPosition + dice1 + dice2);
                if (_currentPosition == 31)
                {
                    Transport(41);
                }
                return _currentPosition;
            }
        }

        public void Move(int destinationPosition)
        {
            CurrentPosition = destinationPosition;
        }

        private void GetSalaryToPassTheGo()
        {
            _money += 200;
        }

        public void PayForFree()
        {
            _money -= 500;
            Transport(11);
        }
        public void GetFree()
        {
            _prisonBreak = 0;
            Transport(11);
        }

        private void Transport(int position)
        {
            _currentPosition = position;
        }


        public bool YesNoQuestion(string message)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", message, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
