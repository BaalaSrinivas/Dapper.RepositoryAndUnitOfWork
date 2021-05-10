using Dapper;
using MoneyTransferApp.Models;
using MoneyTransferApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransferApp.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private SqlConnection _sqlConnection;

        private IDbTransaction _dbTransaction;

        public TransferRepository(SqlConnection sqlConnection, IDbTransaction dbTransaction)
        {
            _dbTransaction = dbTransaction;
            _sqlConnection = sqlConnection;
        }

        public bool AddNew(Transfer transfer)
        {
            var sql = "INSERT INTO Transfers(Id, SourceUserId, TargetUserId, Amount, Timestamp) VALUES (@Id, @SourceUserId, @TargetUserId, @Amount, @Timestamp)";
            return _sqlConnection.Execute(sql, transfer, transaction: _dbTransaction) > 0;
        }
    }
}
