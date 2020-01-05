using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EncModel._277CA
{
    public class _277CAFile
    {
        [Key]
        public int FileId { get; set; }

        public string FileName { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string TransactionDate { get; set; }
        public string TransactionTime { get; set; }
        public string ICN { get; set; }
        public string BatchId { get; set; }
        public string TotalAcceptedQuantity { get; set; }
        public string TotalRejectedQuantity { get; set; }
        public string TotalAcceptedAmount { get; set; }
        public string TotalRejectedAmount { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
