using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zadanie_3_Wpf
{
    class MyCommands
    {
        public static RoutedCommand Exit { get; set; }
        public static RoutedCommand Bold { get; set; }
        public static RoutedCommand Italic { get; set; }
        public static RoutedCommand Underline { get; set; }
        public static RoutedCommand LightTheme { get; set; }
        public static RoutedCommand DarkTheme { get; set; }


        static MyCommands()
        {
            InputGestureCollection input = new InputGestureCollection();
            input.Add(new KeyGesture(Key.T, ModifierKeys.Control, "Ctrl+T"));
            Exit = new RoutedCommand("Exit",typeof(MyCommands),input);
            Bold = new RoutedCommand();
            Italic = new RoutedCommand();
            Underline = new RoutedCommand();
            LightTheme = new RoutedCommand();
            DarkTheme = new RoutedCommand();

        }

    }
}
