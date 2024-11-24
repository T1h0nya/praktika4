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
    /// Логика взаимодействия для UserPersonalCabinetPage.xaml
    /// </summary>
    public partial class UserPersonalCabinetPage : Page
    {
        public List<Expense> Expenses { get; set; } = new List<Expense>();

        public UserPersonalCabinetPage(string fullName)
        {
            InitializeComponent();
            WelcomeMessage.Text = $"Добро пожаловать, {fullName}.";
        }

        private void AddExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            string category = ExpenseCategoryInput.Text;

            string dcb = AmountInput.Text;

            if (!string.IsNullOrEmpty(category) && !string.IsNullOrEmpty(dcb))
            {
                Expenses.Add(new Expense { Category = category, Amount = Convert.ToDecimal(AmountInput.Text) });
                UpdateExpensesList();
                ExpenseCategoryInput.Clear();
                AmountInput.Clear();
            }
            else
            {
                MessageBox.Show("Введите категорию и расход.");
            }
        }

        private void RemoveExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            if (ExpensesList.SelectedItem is Expense selectedBook)
            {
                Expenses.Remove(selectedBook);
                UpdateExpensesList();
            }
            else
            {
                MessageBox.Show("Выберите расход для удаления.");
            }
        }

        // обновление списка книг
        private void UpdateExpensesList()
        {
            ExpensesList.Items.Clear();
            foreach (var expense in Expenses)
            {
                ExpensesList.Items.Add(expense);
            }
        }
    }
}

