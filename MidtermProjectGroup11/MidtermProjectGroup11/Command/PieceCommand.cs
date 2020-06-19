using MidtermProjectGroup11.Enum;
using MidtermProjectGroup11.Interface;
using MidtermProjectGroup11.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjectGroup11.Command
{
    public class PieceCommand : ICommand
    {
        private readonly Piece _piece;
        private readonly PieceAction _pieceAction;

        public PieceCommand(Piece piece, PieceAction pieceAction)
        {
            _piece = piece;
            _pieceAction = pieceAction;
        }

        public void ExecuteAction()
        {
            if (_pieceAction == PieceAction.ShowPieceInfo)
            {
                _piece.ToString();
            }
        }
    }
}
