using System;

namespace OrdersApp.DAL.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.")
        {

        }
    }
}
