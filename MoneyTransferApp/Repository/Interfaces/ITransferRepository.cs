using MoneyTransferApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransferApp.Repository.Interfaces
{
    public interface ITransferRepository
    {
        bool AddNew(Transfer transfer);
    }
}
