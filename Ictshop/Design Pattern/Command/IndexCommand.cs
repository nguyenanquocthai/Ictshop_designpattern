using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ictshop.Design_Pattern.Command
{
    public class IndexCommand : ICommand
    {
        private readonly DonhangsController _controller;

        public IndexCommand(DonhangsController controller)
        {
            _controller = controller;
        }

        public void Execute()
        {
            _controller.CheckLoggedInAndDisplayOrders();
        }
    }
}
