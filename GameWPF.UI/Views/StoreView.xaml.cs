using GameWPF.Core.Managers;
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
using GameWPF.Core.Models;
using System.Drawing.Imaging;

namespace GameWPF.UI.Views
{
    /// <summary>
    /// Interaction logic for StoreView.xaml
    /// </summary>
    public partial class StoreView : UserControl
    {
        public event EventHandler? BackToActionMenu;
        public StoreView()
        {
            InitializeComponent();

            ItemsListBox.ItemsSource = StoreManager.Catalog;
        }
        private void ItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is not Item item)
                return;
            BuyItemButton.IsEnabled = StoreManager.CanBuy(GameManager.Player, item);
        }
        public void BackToActionViewMenuButtonClick(object sender, RoutedEventArgs e)
        {
            BackToActionMenu?.Invoke(null, EventArgs.Empty);
        }
        public void BuyItemButtonClick(object sender, RoutedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is not Item item)
                return;
            bool result = StoreManager.BuyItem(GameManager.Player, item);

            if (result)
                MessageBox.Show($"You bougth: {item.Name}");
            else
                MessageBox.Show("You do not have enough money", "Error" , MessageBoxButton.OK, MessageBoxImage.Error);
        }

        
    }
}
