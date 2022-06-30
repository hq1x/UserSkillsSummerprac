using System;
using System.Collections.Generic;
using UsersSkills.Entities;


namespace UsersSkills.BLL.Interfaces
{
   public interface IAccountBLL
    {
        void AddAccount(Account account);
        void RemoveAccount(int id);
        void EditAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
        Account SearchAccountForAuth(string login, string password);
    }
}
