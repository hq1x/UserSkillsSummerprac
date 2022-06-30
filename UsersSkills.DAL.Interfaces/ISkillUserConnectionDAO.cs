using UsersSkills.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersSkills.DAL.Interfaces
{
   public interface ISkillUserConnectionDAO
    {
        void AddSkillUserConnection(int userID, int skillID);
        void RemoveSkillUserConnection(int userID, int skillID);
        IEnumerable<Skill> GetAllSkillsByUser(int userID);
    }
}
