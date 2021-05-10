using MoneyTransferApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransferApp.Repository.UnitOfWork
{
    public class UnitofWork : IUnitofWork, IDisposable
    {
        public ITransferRepository TransferRepository { get; }

        public IUserRepository UserRepository { get; }

        IDbTransaction _dbTransaction;

        public UnitofWork(IDbTransaction dbTransaction, ITransferRepository transferRepository, IUserRepository userRepository)
        {
            TransferRepository = transferRepository;
            UserRepository = userRepository;
            _dbTransaction = dbTransaction;
        }

        public void Commit()
        {
            try
            {
                _dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                _dbTransaction.Rollback();
            }
        }

        public void Dispose()
        {
            //Close the SQL Connection and dispose the objects
            _dbTransaction.Connection?.Close();
            _dbTransaction.Connection?.Dispose();
            _dbTransaction.Dispose();
        }
    }
}
