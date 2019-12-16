using System.Windows.Input;

namespace Lab4GameControls
{
    public static class GameCommands
    {
        static GameCommands()
        {
            Start = new RoutedCommand("Start", typeof(GameControl));
            Pause = new RoutedCommand("Pause", typeof(GameControl));
            Reset = new RoutedCommand("Reset", typeof(GameControl));
            Fire = new RoutedCommand("Fire", typeof(GameControl));
        }

        public static RoutedCommand Start { get; set; }
        public static RoutedCommand Pause { get; set; }
        public static RoutedCommand Reset { get; set; }
        public static RoutedCommand Fire { get; set; }
    }
}
