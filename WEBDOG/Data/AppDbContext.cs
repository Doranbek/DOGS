using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WEBDOG.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            this.Database.SetCommandTimeout(90);
        }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<ViewDog> ViewDogs { get; set; }
        public DbSet<Coato> Coats { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<DogDaary> DogDaarys { get; set; }
        public DbSet<DogKaroo> DogKaroos { get; set; }
        public DbSet<View_KarooDaary> View_KarooDaary { get; set; }
        public DbSet<View_SvodDaary> View_SvodDaary { get; set; }
        public DbSet<View_SvodDogKaroo> View_SvodDogKaroo { get; set; }
        public DbSet<ViewSvodAimak> ViewSvodAimak { get; set; }
        public DbSet<ViewSvodAimaksD> ViewSvodAimaksD { get; set; }


    }
}
