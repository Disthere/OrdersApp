using OrdersApp.Domain.Entities.OrdersAggregate;
using System.Collections.Generic;
using System.Linq;

namespace OrdersApp.DAL.Persistence
{
    public class DbInitializer
    {
        public static void AddInitialValues(ApplicationDbContext context)
        {
            using (context)
            {
                if (!context.Providers.Any())
                {
                    Provider provider1 = new Provider { Name = "Поставщик 1" };
                    Provider provider2 = new Provider { Name = "Поставщик 2" };
                    Provider provider3 = new Provider { Name = "Поставщик 3" };
                    Provider provider4 = new Provider { Name = "Поставщик 4" };
                    Provider provider5 = new Provider { Name = "Поставщик 5" };
                    Provider provider6 = new Provider { Name = "Поставщик 6" };
                    Provider provider7 = new Provider { Name = "Поставщик 7" };

                    context.Providers.AddRangeAsync(new List<Provider>
                        { provider1,
                          provider2,
                          provider3,
                          provider4,
                          provider5,
                          provider6,
                          provider7
                        });

                    context.SaveChangesAsync();
                }
            }
        }
    }
}
