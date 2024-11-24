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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordInput.Password;
            string confirmPassword = ConfirmPasswordInput.Password;

            if (password == confirmPassword)
            {
                string fullName = $"{LastNameInput.Text} {FirstNameInput.Text} {MiddleNameInput.Text}";
                string email = EmailInput.Text;

                // создаем нового пользователя
                User newUser = new User
                {
                    FullName = fullName,
                    Email = email,
                    Password = password
                };

                // добавления пользователя в список зарегестрированных 
                AuthorizationPage.RegisteredUsers.Add(newUser);

                MessageBox.Show($"{FirstNameInput.Text}, вы зарегистрировались!");

                // открываем личный кабинет
                this.NavigationService.Navigate(new UserPersonalCabinetPage(fullName));
            }
            else
            {
                MessageBox.Show("Пароли не совпадают.");
            }
        }
    }
}
