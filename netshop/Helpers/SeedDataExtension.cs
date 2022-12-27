﻿using netshop.Repositories;
using netshop.Services;

namespace netshop.Helpers
{
    public static class SeedDataExtension
    {
        public static void SeedData(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MainDBContext>();
                var seedDataService = scope.ServiceProvider.GetRequiredService<ISeedDataService>();

                seedDataService.Initialize(dbContext);
            }
        }
    }
}
