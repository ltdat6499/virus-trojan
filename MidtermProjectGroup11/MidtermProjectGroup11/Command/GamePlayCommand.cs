using MidtermProjectGroup11.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MidtermProjectGroup11.GamePlay;
using MidtermProjectGroup11.Enum;

namespace MidtermProjectGroup11.Command
{
    public class GamePlayCommand : ICommand
    {
        private readonly GamePlayControll _gamePlay;
        private readonly PlayerAction _playerAction;
        private readonly int _position;

        public GamePlayCommand(GamePlayControll gamePlay, PlayerAction playerAction)
        {
            _gamePlay = gamePlay;
            _playerAction = playerAction;
        }
        public GamePlayCommand(GamePlayControll gamePlay, PlayerAction playerAction, int position)
        {
            _gamePlay = gamePlay;
            _playerAction = playerAction;
            _position = position;
        }
        public void ExecuteAction()
        {
            if (_playerAction == PlayerAction.MoveForMainPlayer)
            {
                _gamePlay.MoveForMainPlayer();
            }
            else if (_playerAction == PlayerAction.SetCurrentPlayer)
            {
                _gamePlay.SetCurrentPlayer();
            }
            else if (_playerAction == PlayerAction.SetListPiece)
            {
                _gamePlay.SetListPiece();
            }
            else if (_playerAction == PlayerAction.SetListPlayer)
            {
                _gamePlay.SetListPlayer();
            }
            else
            {
                _gamePlay.IsEndGame();
            }
        }
    }
}
