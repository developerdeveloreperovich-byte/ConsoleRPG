using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameWPF.UI.Views
{
    /// <summary>
    /// Interaction logic for MainMenuView.xaml
    /// </summary>
    public partial class MainMenuView : UserControl
    {
        public string? messageBoxReadRulesInfo = "Rules are simple!\n1 - Enjoy playing\n2 - There`s no other rules, so good luck!";
        public event EventHandler? StartGameRequested;
        public event EventHandler? ContinueGameRequested;
        public MainMenuView()
        {
            InitializeComponent();
            StartMessage();
        }
        public void StartMessage()
        {
            GreetingControl.Content = "Hey, welcome to the MEGARPG";
        }
        private void StartGameButtonClick(object sender, RoutedEventArgs e)
        {
            StartGameRequested?.Invoke(this, EventArgs.Empty);
        }
        private void ContinueGameButtonClick(object sender, RoutedEventArgs e)
        {
            ContinueGameRequested?.Invoke(this, EventArgs.Empty);
        }
        private void ReadRulesButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(messageBoxReadRulesInfo, "Rules", MessageBoxButton.OK);
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
    }
}
