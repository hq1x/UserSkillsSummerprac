using UsersSkills.Entities;
using System;
using System.Collections.Generic;


namespace UsersSkills.BLL.Interfaces
{
   public interface ISkillBLL
    {
        void AddSkill(Skill skill);
        void RemoveSkill(int id);
        void EditSkill(Skill skill);
        IEnumerable<Skill> GetAllSkills();


    }
}
