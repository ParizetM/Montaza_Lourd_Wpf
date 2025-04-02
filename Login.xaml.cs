using Montaza_Lourd_Wpf.Classes;
using System.Security.Cryptography;
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

namespace Montaza_Lourd_Wpf
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;
            //email = "admin@atlantismontaza.fr";
            //password = "Not24get";
            User? user = AuthenticateUser(email, password);
            if (user != null)
            {
                loggedIn(user);
            }
            else
            {
                MessageBox.Show("Email ou mot de passe incorrect !");
            }
        }

        private User AuthenticateUser(string email, string password)
        {
            using (var db = new AppDbContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Email == email);
                if (user != null && VerifyPassword(password, user.Password))
                {
                    if (user.RoleId == 1)
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }

        private void loggedIn(User user)
        {
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.IsLoggedIn = true;
            mainWindow.LoggedUser = user; // Use the instance of MainWindow to set LoggedUser
            if (user != null)
            {
                mainWindow.UserNameTextBlock.Text = user.FirstName + " " + user.LastName;
            }
            mainWindow.LogoutButton.Visibility = Visibility.Visible;
            mainWindow.MainFrame.Navigate(new Home());
        }
    }
}