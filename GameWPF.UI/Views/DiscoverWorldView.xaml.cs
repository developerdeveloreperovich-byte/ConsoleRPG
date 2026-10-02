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
using GameWPF.Core.Constants;
using GameWPF.Core.Enums;
using GameWPF.Core.Interfaces;
using GameWPF.Core.Managers;
using GameWPF.Core.Models;

namespace GameWPF.UI.Views
{
    /// <summary>
    /// Interaction logic for DiscoverWorldView.xaml
    /// </summary>
    public partial class DiscoverWorldView : UserControl
    {
        public event EventHandler? BackToActionMenu;
        public event EventHandler? BackToMainMenuRequested;
        public event EventHandler? GoToBattleMenu;
        public DiscoverWorldView()
        {
            InitializeComponent();

        }
        public void BackToActionViewMenuButtonClick(object sender, RoutedEventArgs e)
        {
            BackToActionMenu?.Invoke(null, EventArgs.Empty);
        }
        private void ShowBattleView(NPC enemy)
        {
            var battleView = new BattleView(GameManager.Player, enemy);
            battleView.BackToActionMenuRequested += (_, _) => BackToActionMenu?.Invoke(this, EventArgs.Empty);
            battleView.BackToMainMenuRequested += (_, _) => BackToMainMenuRequested?.Invoke(this, EventArgs.Empty);
            Content = battleView;
        }
        public void GoDiscoverButtonClick(object sender, RoutedEventArgs e)
        {
            var foundObj = GameManager.DiscoverWorld(GameManager.Player);

            if (foundObj is Gold gold)
            {
                RewardManager.RewardPlayer(GameManager.Player, gold.GoldAmount);
                MessageBox.Show($"Wow, you have found {gold.GoldAmount} gold!","DiscoverResult",MessageBoxButton.OK);
            }
            else if (foundObj is DiscoveredNPC npc)
            {
                MessageBox.Show($"Oops, an enemy {npc.NPC.Name} has approach you.. your battle is about to begin!", "DiscoverResult", MessageBoxButton.OK);
                ShowBattleView(npc.NPC);
            }
            else
            {
                MessageBox.Show("Oops, an error! there is no such discover result..", "DiscoverResult", MessageBoxButton.OK);
            }
        }
    }
}
