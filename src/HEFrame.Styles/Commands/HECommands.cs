using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HEFrame.Styles.Commands
{
    public class HECommands
    {
        public static RoutedCommand ExpanderMenuItemSwitchCommand { get; private set; }
        static HECommands()
        {
            ExpanderMenuItemSwitchCommand = new RoutedCommand("ExpanderMenuItemSwitch", typeof(HECommands));
        }
    }
}
