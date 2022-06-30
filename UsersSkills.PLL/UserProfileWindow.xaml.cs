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
    /// Логика взаимодействия для UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        private IAccountBLL accountBL;
        private IUserBLL userBL;
        private ISkillBLL skillBL;
        private ISkillUserConnectionBLL skillUserConnectionBL;
        Account account;
        User user;
        public UserProfileWindow(Account account)
        {
            accountBL = new AccountBL();
            userBL = new UserBL();
            skillBL = new SkillBL();
            skillUserConnectionBL = new SkillUserConnectionBL();
            this.account = account;
            user = userBL.GetUserByID(account.UserID);
            InitializeComponent();
            skillsComboBox.ItemsSource = skillBL.GetAllSkills();
            skillsListBox.ItemsSource = skillUserConnectionBL.GetAllSkillsByUser(user.ID);
            userInfoTextBox.Text = $"Информация о пользователе: \n" +
                    $"Имя: {user.Name} \n" +
                    $"Дата рождения: {user.Birthday.ToShortDateString()} \n" +
                    $"О себе: {user.Description} \n" +
                    $"Логин: {account.UserLogin} \n" +
                    $"Пароль: {account.UserPassword} \n" +
                    $"Роль: {account.UserRole} \n";
        }
        private void addSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (skillsComboBox.SelectedItem != null)
            {
                Skill skill = (Skill)skillsComboBox.SelectedItem;
                skillUserConnectionBL.AddSkillUserConnection(user.ID, skill.ID);
                skillsListBox.ItemsSource = skillUserConnectionBL.GetAllSkillsByUser(user.ID);
            }
            else
            {
                MessageBox.Show("Чтобы добавить навык, выберите его в списке!");
            }
        }

        private void removeSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (skillsListBox.SelectedItem != null)
            {
                Skill skill = (Skill)skillsListBox.SelectedItem;
                skillUserConnectionBL.RemoveSkillUserConnection(user.ID, skill.ID);
                skillsListBox.ItemsSource = skillUserConnectionBL.GetAllSkillsByUser(user.ID);
            }
            else
            {
                MessageBox.Show("Чтобы удалить достижение, выберите его в списке!");
            }
        }

        private void removeUserButton_Click(object sender, RoutedEventArgs e)
        {
            userBL.RemoveUser(user.ID);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void editUserButton_Click(object sender, RoutedEventArgs e)
        {
            EditUserWindow editUserWindow = new EditUserWindow(user, account);

            //Создаем анонимный метод - обработчик события FormClosing дочерней формы (возникающего перед закрытием)
            //Подписаться на событие необходимо до открытия дочерней формы
            //Использовать событие FormClosed не стоит, так как оно возникает уже после закрытия формы, когда все переменные формы уже уничтожены
            editUserWindow.Closing += (sender1, e1) =>
            {
                user = editUserWindow.newUser;
                account = editUserWindow.newAccount;
            };
            //Открывает форму на просмотр
            editUserWindow.ShowDialog();
            userInfoTextBox.Text = $"Информация о пользователе: \n" +
                    $"Имя: {user.Name} \n" +
                    $"Дата рождения: {user.Birthday.ToShortDateString()} \n" +
                    $"О себе: {user.Description} \n" +
                    $"Логин: {account.UserLogin} \n" +
                    $"Пароль: {account.UserPassword} \n" +
                    $"Роль: {account.UserRole} \n";
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

        private void signOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            //Hide();
        }
    }
}
