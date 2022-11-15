using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp.DAL.Common.QueryStatuses
{
    public class NotFoundStatus : Exception
    {
        public NotFoundStatus(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.")
        {

        }
    }
}
