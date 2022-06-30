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
using UsersSkills.BLL;
using UsersSkills.Entities;
using UsersSkills.BLL.Interfaces;

namespace UsersSkills.PLL
{
    /// <summary>
    /// Логика взаимодействия для AddSkillWindow.xaml
    /// </summary>
    /// 
   
    public partial class AddSkillWindow : Window
    {
        private ISkillBLL skillBL;
        public AddSkillWindow()
        {
            skillBL = new SkillBL();
            InitializeComponent();
        }
        private void addSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
                MessageBox.Show("Введите название!");
            else if (descriptionTextBox.Text == "")
                MessageBox.Show("Введите описание!");
            else
            {
                Skill skill = new Skill(nameTextBox.Text, descriptionTextBox.Text);
                skillBL.AddSkill(skill);
                Close();
            }
        }
    }
}
