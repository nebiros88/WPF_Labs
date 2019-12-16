using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;

namespace Lab4GameControls
{
    public partial class GameControl : UserControl
    {
        
        public GameControl()
        {
            this.InitializeComponent();
            this.Context.Init();
        }

    
        public event EventHandler Win;
        public event EventHandler GameOver;

       
        public string SelectedObjectInfo
        {
            get { return (string)this.GetValue(SelectedObjectInfoProperty); }
            set
            {
                this.SetValue(SelectedObjectInfoProperty, value);
            }
        }

         public static readonly DependencyProperty SelectedObjectInfoProperty = DependencyProperty.Register("SelectedObjectInfo", typeof(string), typeof(GameControl), new UIPropertyMetadata(string.Empty));


        private void StartCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Context.Start();
        }

       
        private void StartCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !this.Context.IsBuisy;
        }

      
        private void PauseCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Context.Pause();
        }

        private void PauseCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Context.IsBuisy;
        }

      
        private void ResetCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            this.Context.Init();
        }

       
        private void ResetCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

     
        private void FireCommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Rect bombObjectRect = this.Context.Bomb.ObjectRect;
            bombObjectRect.Location = this.Context.Bomber.ObjectRect.Location;
            this.Context.Bomb.ObjectRect = bombObjectRect;
            this.Context.Bomb.Init();
        }

    
        private void FireCommandBinding_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Context.IsBuisy && !this.Context.Bomb.IsEnabled;
        }

        
        private void Element_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
           
            object obj = (sender as FrameworkElement).DataContext;
           
            this.SetBinding(SelectedObjectInfoProperty, new Binding("State") { Source = obj});
        }
    }
}
