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
    /// Логика взаимодействия для EditSkillWindow.xaml
    /// </summary>
    public partial class EditSkillWindow : Window
    {
        private ISkillBLL skillBL;
        Skill skill;
        public EditSkillWindow(Skill skill)
        {
            skillBL = new SkillBL();
            InitializeComponent();
            this.skill = skill;
            nameTextBox.Text = skill.Name;
            descriptionTextBox.Text = skill.Description;
        }
        private void editSkillButton_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text == "")
                MessageBox.Show("Введите название!");
            else if (descriptionTextBox.Text == "")
                MessageBox.Show("Введите описание!");
            else
            {
               Skill newSkill = new Skill(skill.ID, nameTextBox.Text, descriptionTextBox.Text);
                skillBL.EditSkill(newSkill);
                Close();
            }
        }
    }
}
