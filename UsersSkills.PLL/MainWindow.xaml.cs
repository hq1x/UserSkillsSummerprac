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
using System.Windows.Shapes;
using UsersSkills.BLL.Interfaces;
using UsersSkills.BLL;
using UsersSkills.Entities;

namespace UsersSkills.PLL
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAccountBLL accountBL;
        public MainWindow()
        {
            accountBL = new AccountBL();
            InitializeComponent();
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == "")
                MessageBox.Show("Введите логин!");
            else if (passwordBox.Password == "")
                MessageBox.Show("Введите пароль!");
            else
            {
                Window window;
                Account account = accountBL.SearchAccountForAuth(loginTextBox.Text, passwordBox.Password);
                if (account == null)
                    MessageBox.Show("Неправильный логин или пароль!");
                else
                {
                    if (account.UserRole.Equals("Администратор"))
                        window = new AdminWindow();
                    else
                        window = new UserProfileWindow(account);
                    window.Show();
                    //Hide();
                }
            }
        }

        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
        }

    }
}
