using GameWPF.Core.Managers;
using GameWPF.Core.Models;
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
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        public InventoryView()
        {
            InitializeComponent();

            ItemsListBox.ItemsSource = GameManager.Player.Inventory;
        }
        public event EventHandler? BackToActionMenu;
        public void BackToActionViewMenuButtonClick(object sender, RoutedEventArgs e)
        {
            BackToActionMenu?.Invoke(null, EventArgs.Empty);
        }
        public void UseItemButtonClick(object sender, RoutedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is not Item item)
                return;
            bool result = GameManager.UseItem(GameManager.Player, item);

            if (result)
                MessageBox.Show($"You used: {item.Name}");
            else
                MessageBox.Show("You can not use this item", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void ItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ItemsListBox.SelectedItem is not Item item)
                return;
            UseItemButton.IsEnabled = true;
        }
    }
}
