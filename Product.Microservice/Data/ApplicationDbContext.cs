﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Product.Microservice.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }
        public DbSet<Model.Product> Products { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
