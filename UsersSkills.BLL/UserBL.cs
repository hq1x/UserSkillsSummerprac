using System;
using System.Collections.Generic;
using UsersSkills.DAL;
using UsersSkills.DAL.Interfaces;
using UsersSkills.BLL.Interfaces;
using UsersSkills.Entities;

namespace UsersSkills.BLL
{
     public class UserBL: IUserBLL
    {
        private IUserDAO userDAO;
        public UserBL()
        {
            userDAO = new UserDAO();
        }
        public User AddUser(User user)
        {
            return userDAO.AddUser(user);
        }
        public void EditUser(User user)
        {
            userDAO.EditUser(user);
        }
        public void RemoveUser(int id)
        {
            userDAO.RemoveUser(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userDAO.GetAllUsers();
        }
        public User GetUserByID(int id)
        {
            return userDAO.GetUserByID(id);
        }

    }
}
