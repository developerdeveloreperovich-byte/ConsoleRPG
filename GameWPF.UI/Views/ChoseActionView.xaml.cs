using GameWPF.Core;
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
using GameWPF.Core.Enums;
using GameWPF.Core.Interfaces;
using GameWPF.Core.Managers;
using GameWPF.Core.Models;
using GameWPF.UI.Services;
using System.Text.Json;
using System.IO;

namespace GameWPF.UI.Views
{

    public partial class ChoseActionView : UserControl
    {
        private object? _actionMenuContent;
        public event EventHandler? BackToMainMenuRequested;
        public ChoseActionView()
        {
            InitializeComponent();
            _actionMenuContent = Content;

        }
        public void BackToMainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            BackToMainMenuRequested?.Invoke(this, EventArgs.Empty);
        }

        public void DiscoverWorldButtonClick(object sender, RoutedEventArgs e)
        {
            var discoveryView = new DiscoverWorldView();
            discoveryView.BackToActionMenu += (_, _) => Content = _actionMenuContent;
            discoveryView.BackToMainMenuRequested += (_, _) => BackToMainMenuRequested?.Invoke(this, EventArgs.Empty);
            Content = discoveryView;
        }
        public void CheckStatsButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"Name: {GameManager.Player.Name}\n" +
                $"HP: {GameManager.Player.Health}\n" +
                $"Strength: {GameManager.Player.Strength}\n" +
                $"Defense: {GameManager.Player.Defense}\n" +
                $"Experience: {GameManager.Player.Experience}\n" +
                $"Gold: {GameManager.Player.Gold}\n" +
                $"Level: {GameManager.Player.Level}\n",
                $"{GameManager.Player.Name}");
        }
        public void CheckInventoryButtonClick(object sender, RoutedEventArgs e)
        {
            var inventoryView = new InventoryView();
            inventoryView.BackToActionMenu += (_, _) => Content = _actionMenuContent;
            Content = inventoryView;
        }



        public void StoreButtonClick(object sender, RoutedEventArgs e)
        {

            var storeView = new StoreView();
            storeView.BackToActionMenu += (_, _) => Content = _actionMenuContent;
            Content = storeView;
        }
        public void SaveProgressButtonClick(object sender, RoutedEventArgs e)
        {
            var player = GameManager.Player;
            CharacterClass characterClass;

            switch (player)
            {
                case Warrior:
                    characterClass = CharacterClass.Warrior;
                    break;
                case Archer:
                    characterClass = CharacterClass.Archer;
                    break;
                case Mage:
                    characterClass = CharacterClass.Mage;
                    break;
                default:
                    throw new InvalidOperationException("Unknown character class.");
            }

            var saveData = new SaveData
            {
                CharacterClass = characterClass,
                Health = player.Health,
                Experience = player.Experience,
                Gold = player.Gold,
                InventoryItemIds = player.Inventory.Select(item => item.Id).ToList()
            };

            try
            {
                SaveService.SaveProgress(saveData);
                MessageBox.Show("Progress saved.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Could not save progress: {exception.Message}", "Save error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void SaveProgress(Character character)
        {
            
        }
    }
}
