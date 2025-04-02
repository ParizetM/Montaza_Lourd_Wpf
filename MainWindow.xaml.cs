using Montaza_Lourd_Wpf.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Montaza_Lourd_Wpf
{
    public partial class MainWindow : Window
    {
        public bool IsLoggedIn { get; internal set; }
        public User? LoggedUser { get; internal set; }

        public MainWindow()
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.SingleBorderWindow;
            // Charge la page d'accueil au démarrage
            MainFrame.Navigate(new Login());
            LogoutButton.Visibility = Visibility.Collapsed;

        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack)
                MainFrame.GoBack();
        }
        private void goHome(object sender, RoutedEventArgs e)
        {
            if (IsLoggedIn)
            {
                MainFrame.Navigate(new Home());
            }
            else
            {
                MainFrame.Navigate(new Login());
            }

        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            IsLoggedIn = false;
            LoggedUser = null;
            UserNameTextBlock.Text = "";
            LogoutButton.Visibility = Visibility.Collapsed;
            MainFrame.Navigate(new Login());
        }
    }
}
