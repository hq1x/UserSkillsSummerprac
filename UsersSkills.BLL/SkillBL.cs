using System;
using System.Collections.Generic;
using UsersSkills.DAL;
using UsersSkills.DAL.Interfaces;
using UsersSkills.BLL.Interfaces;
using UsersSkills.Entities;

namespace UsersSkills.BLL
{
   public class SkillBL: ISkillBLL
    {
        private ISkillDAO skillDAO;
        public SkillBL()
        {
           skillDAO = new SkillDAO();
        }
        public void AddSkill(Skill skill)
        {
            skillDAO.AddSkill(skill);
        }
        public void EditSkill(Skill skill)
        {
            skillDAO.EditSkill(skill);
        }
        public void RemoveSkill(int id)
        {
            skillDAO.RemoveSkill(id);
        }

        public IEnumerable<Skill> GetAllSkills()
        {
            return skillDAO.GetAllSkills();
        }
    }
}
