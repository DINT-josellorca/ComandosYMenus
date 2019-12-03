using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComandosYMenus
{
    class Comandos
    {
        public static readonly RoutedUICommand Vaciar = new RoutedUICommand(
            "Vaciar",
            "Vaciar",
            typeof(Comandos),
            new InputGestureCollection()
            {
                new KeyGesture(Key.R,ModifierKeys.Control)
            }
        );
        public static readonly RoutedUICommand Salir = new RoutedUICommand(
            "Salir",
            "Salir",
            typeof(Comandos),
            new InputGestureCollection()
            {
                        new KeyGesture(Key.S,ModifierKeys.Control)
            }
        );
    }
}
