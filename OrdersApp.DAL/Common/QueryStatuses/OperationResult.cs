using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.DAL.Common.QueryStatuses
{
    public class OperationResult
    {
        public bool Found { get; set; }
        public DateTime OperationDate { get; set; } = DateTime.Now;
    }
}
