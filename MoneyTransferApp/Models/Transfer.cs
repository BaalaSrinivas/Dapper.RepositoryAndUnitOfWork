using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyTransferApp.Models
{
    public class Transfer
    {
        public string Id { get; set; }

        public string SourceUserId { get; set; }

        public string TargetUserId { get; set; }

        public double Amount { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
