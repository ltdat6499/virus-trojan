using MidtermProjectGroup11.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProjectGroup11.Invoker
{
    public class Modify
    {
        private readonly List<ICommand> _commands;
        private ICommand _command;

        public Modify()
        {
            _commands = new List<ICommand>();
        }

        public void SetCommand(ICommand command) => _command = command;

        public void Invoke()
        {
            _commands.Add(_command);
            _command.ExecuteAction();
        }
    }
}
