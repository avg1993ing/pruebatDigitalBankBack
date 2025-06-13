using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Persistence.ConfigurationEntity
{
    public class ContexDBConfig : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Usuarios");
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();
            builder.Property(p => p.Nombre).HasColumnName("Nombre").ValueGeneratedNever();
            builder.Property(p => p.FechaNacimiento).HasColumnName("FechaNacimiento").ValueGeneratedNever();
            builder.Property(p => p.Sexo).HasColumnName("Sexo").ValueGeneratedNever();
        }
    }
}
