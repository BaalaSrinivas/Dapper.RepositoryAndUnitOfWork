using Dapper;
using MoneyTransferApp.Models;
using MoneyTransferApp.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MoneyTransferApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private SqlConnection _sqlConnection;

        private IDbTransaction _dbTransaction;

        public UserRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
            _sqlConnection = sqlConnection;
        }

        public bool Credit(string userId, double amount)
        {
            var sql = "UPDATE Users SET CurrentBalance = CurrentBalance + @amount WHERE Id = @userId";
            return _sqlConnection.Execute(sql, new { userId = userId, amount = amount }, transaction: _dbTransaction) > 0;
        }

        public bool Debit(string userId, double amount)
        {
            var sql = "UPDATE Users SET CurrentBalance = CurrentBalance - @amount WHERE Id = @userId";
            return _sqlConnection.Execute(sql, new { userId = userId, amount = amount }, transaction: _dbTransaction) > 0;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var sql = "SELECT * FROM Users";
            return _sqlConnection.Query<User>(sql);
        }

        public User GetUserDetails(string userId)
        {
            var sql = "SELECT * FROM Users WHERE Id=@userId";
            return _sqlConnection.QueryFirst<User>(sql, new { userId = userId }, transaction: _dbTransaction);
        }
    }
}
