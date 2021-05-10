using MoneyTransferApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransferApp.Repository.UnitOfWork
{
    public interface IUnitofWork
    {
        ITransferRepository TransferRepository { get; }
        IUserRepository UserRepository { get; }

        void Commit();
    }
}
