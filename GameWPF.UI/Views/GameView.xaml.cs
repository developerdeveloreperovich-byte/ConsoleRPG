using GameWPF.Core;
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
using GameWPF.Core.Enums;
using GameWPF.Core.Constants;
using GameWPF.Core.Interfaces;

namespace GameWPF.UI.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        public string warriorInfo = $"" +
            $"Class Name = {GameConstants.DefaultWarriorName}\n" +
            $"Health = {GameConstants.DefaultWarriorBaseHealth}\n" +
            $"Strength = {GameConstants.DefaultWarriorStrength}\n" +
            $"Defense = {GameConstants.DefaultWarriorDefense}\n" +
            $"Experience = {GameConstants.DefaultCharacterExperience}\n" +
            $"Gold = {GameConstants.DefaultCharacterGold}";
        public string archerInfo = $"" +
            $"Class Name = {GameConstants.DefaultArcherName}\n" +
            $"Health = {GameConstants.DefaultArcherBaseHealth}\n" +
            $"Strength = {GameConstants.DefaultArcherStrength}\n" +
            $"Defense = {GameConstants.DefaultArcherDefense}\n" +
            $"Experience = {GameConstants.DefaultCharacterExperience}\n" +
            $"Gold = {GameConstants.DefaultCharacterGold}";
        public string mageInfo = $"" +
            $"Class Name = {GameConstants.DefaultMageName}\n" +
            $"Health = {GameConstants.DefaultMageBaseHealth}\n" +
            $"Strength = {GameConstants.DefaultMageStrength}\n" +
            $"Defense = {GameConstants.DefaultMageDefense}\n" +
            $"Experience = {GameConstants.DefaultCharacterExperience}\n" +
            $"Gold = {GameConstants.DefaultCharacterGold}";


        public event EventHandler? BackToMainMenuRequested;
        public GameView()
        {
            InitializeComponent();

            WarriorInfo.Content = warriorInfo;
            ArcherInfo.Content = archerInfo;
            MageInfo.Content = mageInfo;
        }

        

        public void ArcherInfoButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(archerInfo, "Archer", MessageBoxButton.OK);

        }
        public void MageInfoButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(mageInfo, "Mage", MessageBoxButton.OK);

        }

        private void ShowActionView()
        {
            ClassSelectionPanel.Visibility = Visibility.Collapsed;
            var actionView = new ChoseActionView();
            actionView.BackToMainMenuRequested += (_, _) => BackToMainMenuRequested?.Invoke(this, EventArgs.Empty);
            ActionContent.Content = actionView;
        }

        public void ContinueSavedGame()
        {
            ShowActionView();
        }

        public void ChooseWarriorButtonClick(object sender, RoutedEventArgs e)
        {
            GameManager.CreateCharacter(CharacterClass.Warrior);
            ShowActionView();
        }
       
        public void ChooseArcherButtonClick(object sender, RoutedEventArgs e)
        {
            GameManager.CreateCharacter(CharacterClass.Archer);
            ShowActionView();
        }
        
        public void ChooseMageButtonClick(object sender, RoutedEventArgs e)
        {
            GameManager.CreateCharacter(CharacterClass.Mage);
            ShowActionView();
        }

        public void BackToMainMenuButtonClick(object sender, RoutedEventArgs e)
        {
            BackToMainMenuRequested?.Invoke(this,EventArgs.Empty);
        }
    }
}
