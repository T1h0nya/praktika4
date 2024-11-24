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

namespace Praktika4
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        // список зарегистрированных пользователей
        public static List<User> RegisteredUsers = new List<User>();
        public AuthorizationPage()
        {
            InitializeComponent();
        }       
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailInput.Text;
            string password = PasswordInput.Password;

            // проверка на наличие пользователя с таким емейл и паролем
            User user = RegisteredUsers.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {

                this.NavigationService.Navigate(new UserPersonalCabinetPage(user.FullName));               
            }
            else
            {
                MessageBox.Show("Неверный E-mail или пароль.");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegistrationPage());
        }
    }

}
