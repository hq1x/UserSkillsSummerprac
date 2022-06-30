using UsersSkills.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersSkills.BLL.Interfaces
{
   public interface IUserBLL
    {
        User AddUser(User user);
        void RemoveUser(int id);
        void EditUser(User user);
        IEnumerable<User> GetAllUsers();
        User GetUserByID(int id);
    }
}
