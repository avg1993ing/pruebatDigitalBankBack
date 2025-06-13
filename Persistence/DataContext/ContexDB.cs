using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.ConfigurationEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Persistence.DataContext
{
    public class ContexDB(DbContextOptions<ContexDB> options) : DbContext(options)
    {
        DbSet<Usuarios> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContexDBConfig());
        }
    }
}
