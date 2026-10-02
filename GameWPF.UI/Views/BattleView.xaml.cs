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
using System.IO;
using GameWPF.Core.Models;
using GameWPF.Core.Managers;
using GameWPF.Core.Interfaces;
using GameWPF.Core.Enums;
using GameWPF.Core.Constants;

namespace GameWPF.UI.Views
{
    /// <summary>
    /// Interaction logic for BattleView.xaml
    /// </summary>
    public partial class BattleView : UserControl
    {

        private Character _player;
        private NPC _npc;
        public event EventHandler? BackToActionMenuRequested;
        public event EventHandler? BackToMainMenuRequested;
        public BattleView(Character character, NPC npc)
        {
            InitializeComponent();
            PlayerInfo(character);
            NPCInfo(npc);
            SetPlayerImage(character);
            SetNPCImage(npc);

            _player = character;
            _npc = npc;
        }
        public void PlayerInfo(Character player)
        {
            PlayerInfoText.Text = $"{player.Name}\n" +
                $"HP: {player.Health}\n" +
                $"Damage: {player.Damage}\n" +
                $"Defense: {player.Defense}\n";
        }
        public void NPCInfo(NPC npc)
        {
            NPCInfoText.Text = $"{npc.Name}\n" +
                $"HP: {npc.Health}\n" +
                $"Damage: {npc.Damage}\n" +
                $"Defense: {npc.Defense}\n";
        }
        private void SetPlayerImage(Character player)
        {
            string imagePath;

            switch (player)
            {
                case Warrior:
                    imagePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Images", "warrior.png");
                    break;
                case Archer:
                    imagePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Images", "Archer.png");
                    break;
                case Mage:
                    imagePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Images", "Mage.png");
                    break;
                default:
                    throw new ArgumentException(
                        "Unknown character class.",
                        nameof(player));
            }
            PlayerPortrait.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }

        private void SetNPCImage(NPC npc)
        {
            string imagePath;

            switch (npc.Name)
            {
                case "Goblin":
                    imagePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Images", "Goblin.png");
                    break;
                case "Orc":
                    imagePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Images", "orc.png");
                    break;
                case "Zombie":
                    imagePath = System.IO.Path.Combine(AppContext.BaseDirectory, "Images", "Zombie.png");
                    break;
                default:
                    throw new ArgumentException("Unknown NPC type.", nameof(npc));
            }
            NPCPortrait.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
        }
        public void AttackButtonClick(object sender, RoutedEventArgs e)
        {
            BattleManager.AttackNpc(_player, _npc);
            NPCInfo(_npc);
            if (_npc.IsDead)
            {
                RewardManager.RewardPlayer(_player, _npc);
                MessageBox.Show("You won!","BattleInfo");
                MessageBox.Show($"You just got {_npc.GoldReward} gold and {_npc.ExperienceReward} xp", "BattleInfo");

                AttackButton.IsEnabled = false;
                RunButton.IsEnabled = false;
                ShowBackToActionsButton();
                return;
            }

            BattleManager.AttackCharacter(_player, _npc);
            PlayerInfo(_player);

            if (_player.IsDead)
            {
                MessageBox.Show("You lost!");
                AttackButton.IsEnabled = false;
                RunButton.IsEnabled = false;
                ShowBackToMainMenuButton();
            }
            
        }
        public void RunButtonClick(object sender, RoutedEventArgs e)
        {
            bool tryEscape = BattleManager.TryRun(_player, _npc);
            if (tryEscape)
            {
                MessageBox.Show("You escaped!");
                AttackButton.IsEnabled = false;
                RunButton.IsEnabled = false;
                ShowBackToActionsButton();
            }
            else if (_player.IsDead)
            {
                MessageBox.Show("You lost!");
                AttackButton.IsEnabled = false;
                RunButton.IsEnabled = false;
                ShowBackToMainMenuButton();

            }
            else
            {
                PlayerInfo(_player);
            }
        }

        private void BackToActionsButtonClick(object sender, RoutedEventArgs e)
        {
            BackToActionMenuRequested?.Invoke(this, EventArgs.Empty);
        }
        public void BackToMainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            BackToMainMenuRequested?.Invoke(this, EventArgs.Empty);
        }
        
        private void ShowBackToActionsButton()
        {
            if (FindName("BackToActionsButton") is Button backButton)
                backButton.Visibility = Visibility.Visible;
        }

        private void ShowBackToMainMenuButton()
        {
            if (FindName("BackToMainMenuButton") is Button backButton)
                backButton.Visibility = Visibility.Visible;
        }
        
    }
}
