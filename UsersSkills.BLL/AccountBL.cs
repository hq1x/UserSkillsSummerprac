using System;
using System.Collections.Generic;
using UsersSkills.DAL;
using UsersSkills.DAL.Interfaces;
using UsersSkills.BLL.Interfaces;
using UsersSkills.Entities;

namespace UsersSkills.BLL
{
   public class AccountBL: IAccountBLL
    {
        private IAccountDAO accountDAO;
        public AccountBL()
        {
            accountDAO = new AccountDAO();
        }
        public void AddAccount(Account account)
        {
            accountDAO.AddAccount(account);
        }
        public void EditAccount(Account account)
        {
            accountDAO.EditAccount(account);
        }
        public void RemoveAccount(int userID)
        {
            accountDAO.RemoveAccount(userID);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountDAO.GetAllAccounts();
        }
        public Account SearchAccountForAuth(string login, string password)
        {
            return accountDAO.SearchAccountForAuth(login, password);
        }

    }
}
