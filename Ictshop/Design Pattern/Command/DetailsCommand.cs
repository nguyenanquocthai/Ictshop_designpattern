using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Ictshop.Design_Pattern.Command
{
    public class DetailsCommand : ICommand
    {
        private readonly DonhangsController _controller;
        private readonly int? _id;

        public DetailsCommand(DonhangsController controller, int? id)
        {
            _controller = controller;
            _id = id;
        }

        public void Execute()
        {
            _controller.DisplayOrderDetails(_id);
        }
    }
}
