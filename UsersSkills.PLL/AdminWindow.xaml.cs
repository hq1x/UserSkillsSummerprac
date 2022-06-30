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
using UsersSkills.BLL.Interfaces;
using UsersSkills.BLL;
using UsersSkills.Entities;

namespace UsersSkills.PLL
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private IUserBLL userBL;
        private IAccountBLL accountBL;
        private ISkillBLL skillBL;
        public AdminWindow()
        {
            userBL = new UserBL();
            accountBL = new AccountBL();
            skillBL = new SkillBL();
            InitializeComponent();
            accountsListBox.ItemsSource = accountBL.GetAllAccounts();
            skillsListBox.ItemsSource = skillBL.GetAllSkills();
        }
        private void addUserButton_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow();
            addUserWindow.ShowDialog();
            accountsListBox.ItemsSource = accountBL.GetAllAccounts();
        }

        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (accountsListBox.SelectedItem != null)
            {
                userBL.RemoveUser(((Account)accountsListBox.SelectedItem).UserID);
                accountsListBox.ItemsSource = accountBL.GetAllAccounts();
            }
            else
            {
                MessageBox.Show("Чтобы удалить пользователя, выберите его в списке!");
            }
        }



        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (accountsListBox.SelectedItem != null)
            {
                Account account = (Account)accountsListBox.SelectedItem;
                User user = userBL.GetUserByID(account.UserID);
                EditUserWindow editUserWindow = new EditUserWindow(user, account);
                editUserWindow.ShowDialog();
                accountsListBox.ItemsSource = accountBL.GetAllAccounts();
            }
            else
            {
                MessageBox.Show("Выберите пользователя, информацию о котором хотите редактировать!");
            }
        }

        private void accountsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (accountsListBox.SelectedItem != null)
            {
                Account account = (Account)accountsListBox.SelectedItem;
                User user = userBL.GetUserByID(account.UserID);
                userInfoTextBox.Text = $"Информация о пользователе: \n" +
                    $"Имя: {user.Name} \n" +
                    $"Дата рождения: {user.Birthday.ToShortDateString()} \n" +
                    $"О себе: {user.Description} \n" +
                    $"Логин: {account.UserLogin} \n" +
                    $"Пароль: {account.UserPassword} \n" +
                    $"Роль: {account.UserRole} \n";
            }
        }

        private void addSkillButton_Click(object sender, RoutedEventArgs e)
        {
            AddSkillWindow addSkillWindow = new AddSkillWindow();
            addSkillWindow.ShowDialog();
            skillsListBox.ItemsSource = skillBL.GetAllSkills();
        }

        private void removeSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (skillsListBox.SelectedItem != null)
            {
                skillBL.RemoveSkill(((Skill)skillsListBox.SelectedItem).ID);
                skillsListBox.ItemsSource = skillBL.GetAllSkills();
            }
            else
            {
                MessageBox.Show("Чтобы удалить навык, выберите его в списке!");
            }
        }

        private void editSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (skillsListBox.SelectedItem != null)
            {
                Skill skill = (Skill)skillsListBox.SelectedItem;
                EditSkillWindow editSkillWindow = new EditSkillWindow(skill);
                editSkillWindow.ShowDialog();
                skillsListBox.ItemsSource = skillBL.GetAllSkills();
            }
            else
            {
                MessageBox.Show("Выберите пользователя, информацию о котором хотите редактировать!");
            }
        }

        private void skillsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (skillsListBox.SelectedItem != null)
            {
                Skill skill = (Skill)skillsListBox.SelectedItem;
                skillInfoTextBox.Text = $"Информация о навыке: \n" +
                    $"Название: {skill.Name} \n" +
                    $"Описание: {skill.Description} \n";
            }
        }
    }
}
