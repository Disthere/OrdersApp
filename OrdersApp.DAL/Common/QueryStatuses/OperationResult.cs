using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.DAL.Common.QueryStatuses
{
    public class OperationResult
    {
        public bool IsFound { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsError { get; set; }
        public DateTime OperationDate { get; set; } = DateTime.Now;
    }
}
