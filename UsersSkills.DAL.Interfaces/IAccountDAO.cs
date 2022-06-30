using UsersSkills.Entities;
using System;
using System.Collections.Generic;

namespace UsersSkills.DAL.Interfaces
{
  public  interface IAccountDAO
    {
        void AddAccount(Account account);
        void RemoveAccount(int id);
        void EditAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
        Account SearchAccountForAuth(string login, string password);
    }
}
