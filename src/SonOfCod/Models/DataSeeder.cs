using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonOfCod.Models
{
    public static class DataSeeder
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            SonOfCodDbContext db = new SonOfCodDbContext();
            MenuInfo newInfo = new MenuInfo();
            db.MenuInfo.Add(newInfo);

            db.SaveChanges();
        }
    }
}
