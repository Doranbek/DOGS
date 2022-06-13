using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WEBDOG.Models;

namespace WEBDOG.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<ViewDog> ViewDogs { get; set; }
        public DbSet<Coato> Coats { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DogDaary> DogDaarys { get; set; }
        public DbSet<DogKaroo> DogKaroos { get; set; }

    }
}
