using System;
using System.Collections.Generic;
using UsersSkills.DAL;
using UsersSkills.DAL.Interfaces;
using UsersSkills.BLL.Interfaces;
using UsersSkills.Entities;


namespace UsersSkills.BLL
{
   public class SkillUserConnectionBL: ISkillUserConnectionBLL
    {
        private ISkillUserConnectionDAO skillUserConnectionDAO;
        public SkillUserConnectionBL()
        {
            skillUserConnectionDAO = new SkillUserConnectionDAO();
        }
        public void AddSkillUserConnection(int userID, int skillID)
        {
            skillUserConnectionDAO.AddSkillUserConnection(userID, skillID);
        }
        public void RemoveSkillUserConnection(int userID, int skillID)
        {
            skillUserConnectionDAO.RemoveSkillUserConnection(userID, skillID);
        }
        public IEnumerable<Skill> GetAllSkillsByUser(int userID)
        {
            return skillUserConnectionDAO.GetAllSkillsByUser(userID);
        }
    }
}
