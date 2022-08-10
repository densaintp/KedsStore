using KedsStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace KedsStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new KedsStoreContext(serviceProvider.GetRequiredService<DbContextOptions<KedsStoreContext>>()))
            {
                if (context.Items.Any())    // Check if database contains any books
                {
                    return;     // Database contains books already
                }

                context.Items.AddRange(
                    new Item
                    {
                        Name = "Nike Air Jordan",
                        ImgPath = "/Images/NikeAirJordan.png",
                        Brand="Nike",
                        Price = 12000
                    },
                    new Item
                    {
                        Name = "Converse",
                        ImgPath = "/Images/Converse.png",
                        Brand = "Converse",
                        Price = 13000
                    },
                    new Item
                    {
                        Name = "New Balance",
                        ImgPath = "/Images/NewBalance.png",
                        Brand = "New Balance",
                        Price = 12000
                    },
                    new Item
                    {
                        Name = "Простые кеды",
                        ImgPath = "/Images/Simple.png",
                        Brand = "Россия",
                        Price = 12000
                    },
                    new Item
                    {
                        Name = "Saucony",
                        ImgPath = "/Images/Saucony.png",
                        Brand = "Saucony",
                        Price = 12000
                    },
                    new Item
                    {
                        Name = "Adidas Yeezy",
                        ImgPath = "/Images/AdidasYeezy.png",
                        Brand = "Adidas",
                        Price = 12000
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
