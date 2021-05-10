using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoneyTransferApp.Models;
using MoneyTransferApp.Repository.UnitOfWork;
using System;

namespace MoneyTransferApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        private IUnitofWork _unitofWork;

        public HomeController(ILogger<HomeController> logger, IUnitofWork unitofWork)
        {
            _logger = logger;
            _unitofWork = unitofWork;
        }

        [HttpPost]
        public string TransferMoney(string sourceUserId, string targetUserId, double amount)
        {
            string result;
            bool flag = true;
            try
            {               
                if (amount <= 0)
                {
                    return "Invalid amount";
                }

                //Fetch source user balance
                User sourceUser = _unitofWork.UserRepository.GetUserDetails(sourceUserId);

                if (sourceUser.CurrentBalance < amount)
                {
                    return "Insufficient Funds";
                }

                //Debit amount
                flag &= _unitofWork.UserRepository.Debit(sourceUserId, amount);
                flag &= _unitofWork.UserRepository.Credit(targetUserId, amount);
                Transfer transfer = new Transfer() { 
                    Id = Guid.NewGuid().ToString(), 
                    SourceUserId = sourceUserId,
                    TargetUserId = targetUserId,
                    Amount = amount,
                    Timestamp = DateTime.UtcNow
                };
                flag &= _unitofWork.TransferRepository.AddNew(transfer);

                _unitofWork.Commit();

                result = flag == true ? "Success" : "Failed";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Transaction failed");
                result = "Failed";
            }

            return result;
        }
    }
}
