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
        public DbSet<Coato> Coats { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<DogDaary> DogDaarys { get; set; }
        public DbSet<DogKaroo> DogKaroos { get; set; }
        public DbSet<OrgUser> OrgUsers { get; set; }
        public DbSet<WEBDOG.Models.DogModel> DogModel { get; set; }
        public DbSet<WEBDOG.Models.DrugModel> DrugModel { get; set; }
    }
}
