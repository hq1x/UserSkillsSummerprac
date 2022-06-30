﻿using UsersSkills.BLL;
using UsersSkills.Entities;
using UsersSkills.BLL.Interfaces;
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


namespace UsersSkills.PLL
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        private IUserBLL userBL;
        private IAccountBLL accountBL;
        User user;
        Account account;
        public User newUser;
        public Account newAccount;
        public EditUserWindow(User user, Account account)
        {
            userBL = new UserBL();
            accountBL = new AccountBL();
            this.user = user;
            this.account = account;
            newUser = user;
            newAccount = account;
            InitializeComponent();
            nameTextBox.Text = user.Name;
            birthdayDatePiker.SelectedDate = user.Birthday;
            if (user.Description != null)
                descriptionTextBox.Text = user.Description;
            loginTextBox.Text = account.UserLogin;
            passwordBox.Password = account.UserPassword;
            roleComboBox.ItemsSource = new List<string> { "Администратор", "Пользователь" };
            roleComboBox.SelectedItem = account.UserRole;
        }
        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            string description = null;
            if (nameTextBox.Text == "")
                MessageBox.Show("Введите имя!");
            else if (birthdayDatePiker.SelectedDate == null)
                MessageBox.Show("Выберите дату рождения!");
            else if (birthdayDatePiker.SelectedDate >= DateTime.Today)
                MessageBox.Show("Дата рождения не может быть позже текущей даты!");
            else if (loginTextBox.Text == "")
                MessageBox.Show("Введите логин!");
            else if (passwordBox.Password == "")
                MessageBox.Show("Введите пароль!");
            else if (roleComboBox.SelectedItem == null)
                MessageBox.Show("Выберите роль!");
            else
            {
                if (descriptionTextBox.Text != "")
                    description = descriptionTextBox.Text;
                newUser = new User(user.ID, nameTextBox.Text, (DateTime)birthdayDatePiker.SelectedDate, description);
                userBL.EditUser(newUser);
                newAccount = new Account(user.ID, loginTextBox.Text, passwordBox.Password, roleComboBox.Text);
                accountBL.EditAccount(newAccount);
                Close();
            }
        }
    }
}
