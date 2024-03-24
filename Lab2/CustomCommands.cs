using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab2
{
    public static class CustomCommands
    {
        public static readonly RoutedUICommand Clean = new RoutedUICommand(
                "Clean",
                "Clean",
                typeof(CustomCommands),
                new InputGestureCollection()
                {
                    new KeyGesture(Key.Back, ModifierKeys.Control)
                }
            );
    }
}
