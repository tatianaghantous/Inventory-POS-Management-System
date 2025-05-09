﻿using Microsoft.EntityFrameworkCore;
using SM.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SM.DataLayer.Models;

namespace SM
{
    internal class DatabaseInitializer
    {
        public static void Initialize(ClothingStoreContext context)
        {
            // Ensure the database is up-to-date and create it if it does not exist
            context.Database.Migrate();  // This will apply any pending migrations and create the database if it doesn't exist
        }

    }
}
