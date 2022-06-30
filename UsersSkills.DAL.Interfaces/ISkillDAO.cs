using UsersSkills.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersSkills.DAL.Interfaces
{
   public interface ISkillDAO
    {
        void AddSkill(Skill skill);
        void RemoveSkill(int id);
        void EditSkill(Skill skill);
        IEnumerable<Skill> GetAllSkills();
    }
}
