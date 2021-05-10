using MoneyTransferApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransferApp.Repository.Interfaces
{
    public interface IUserRepository
    {
       bool Debit(string userId, double amount);

       bool Credit(string userId, double amount);

       User GetUserDetails(string userId);

       IEnumerable<User> GetAllUsers();

    }
}
