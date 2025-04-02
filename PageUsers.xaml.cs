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
    /// <summary>
    /// Logique d'interaction pour PageUsers.xaml
    /// </summary>
    public partial class PageUsers : Page
    {
        private AppDbContext _context;

        public PageUsers()
        {
            InitializeComponent();
            _context = new AppDbContext();
            LoadUsers();
        }

        private void LoadUsers()
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            string currentUserEmail = mainWindow.LoggedUser.Email;
            var users = _context.Users.Where(u => u.Email != currentUserEmail).ToList();
            UsersDataGrid.ItemsSource = users;
        }
        private void ReinitialiserMotDePasse(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                string newPassword = GenerateRandomPassword();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword, workFactor: 12);
                hashedPassword = hashedPassword.Replace("$2a$", "$2y$");
                selectedUser.Password = hashedPassword;
                _context.SaveChanges();
                MessageBox.Show($"Le mot de passe a été réinitialisé. Nouveau mot de passe : {newPassword}", "Réinitialisation du mot de passe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void DésactiverLeCompte(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                selectedUser.DeletedAt = DateTime.UtcNow; // Use UTC time
                _context.SaveChanges();
                MessageBox.Show("Le compte a été désactivé.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ReactiverLeCompte(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem is User selectedUser)
            {
                selectedUser.DeletedAt = null;
                _context.SaveChanges();
                MessageBox.Show("Le compte a été réactivé.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void EssayerDeSeConnecter(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                MessageBox.Show("Connexion réussie.", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Échec de la connexion. Veuillez vérifier vos identifiants.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
