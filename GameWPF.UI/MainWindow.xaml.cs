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
using GameWPF.Core;
using GameWPF.Core.Managers;
using GameWPF.UI.Services;
using GameWPF.UI.Views;

namespace GameWPF.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var menu = new MainMenuView();
            menu.StartGameRequested += (_, _) =>
            {
                ShowGame(menu, continueSavedGame: false);
            };
            menu.ContinueGameRequested += (_, _) => ContinueGame(menu);
            ScreenHost.Content = menu;

        }

        private void ContinueGame(MainMenuView menu)
        {
            try
            {
                var saveData = SaveService.LoadProgress();
                if (saveData is null)
                {
                    MessageBox.Show("No saved game was found.", "Continue", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }

                GameManager.RestorePlayer(saveData);
                ShowGame(menu, continueSavedGame: true);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Could not load saved game: {exception.Message}", "Load error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ShowGame(MainMenuView menu, bool continueSavedGame)
        {
            var gameView = new GameView();
            gameView.BackToMainMenuRequested += (_, _) => ScreenHost.Content = menu;

            if (continueSavedGame)
                gameView.ContinueSavedGame();

            ScreenHost.Content = gameView;
        }
    }
}