using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersSkills.Entities
{
   public class SkillUserConnection
    {
        public int UserID { get; set; }
        public int SkillID { get; set; }
        public SkillUserConnection(int userID, int skillID)
        {
            UserID = userID;
            SkillID = skillID;
        }
    }
}
