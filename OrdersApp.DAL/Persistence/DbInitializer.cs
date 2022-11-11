using OrdersApp.Domain.Entities.OrdersAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                    //Game game1 = new Game { Title = "Days Gone" };
                    //game1.Developer = dev3;
                    //game1.Genres.Add(genre2);
                    //game1.Genres.Add(genre3);

                    //Game game2 = new Game { Title = "Doom Eternal" };
                    //game2.Developer = dev2;
                    //game2.Genres.Add(genre1);

                    //Game game3 = new Game { Title = "Portal 2" };
                    //game3.Developer = dev1;
                    //game3.Genres.Add(genre1);
                    //game3.Genres.Add(genre5);

                    //Game game4 = new Game { Title = "Half life 3" };
                    //game4.Developer = dev1;
                    //game4.Genres.Add(genre1);
                    //game4.Genres.Add(genre3);

                    //context.Games.AddRange(new List<Game> { game1, game2, game3, game4 });
                    //context.SaveChanges();
                }
            }
        }
    }
}
