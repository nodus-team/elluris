using Microsoft.EntityFrameworkCore;
using Nodus.Elluris.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nodus.Elluris.Data.ORM
{
    public class NodusArtDbContext : DbContext
    {
        public NodusArtDbContext(DbContextOptions<NodusArtDbContext> options)
            :base(options)
        { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Obras> Obras { get; set; }
        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<BeaconObra> BeaconObras { get; set; }
        public DbSet<EventoPeriodo> EventoPeriodos { get; set; }
        public DbSet<ObraEvento> ObraEventos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // busca os Mappings de uma só vez
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NodusArtDbContext).Assembly);

            // onde não tiver setado varchar e a propriedade for do tipo string fica valendo
            // varchar(100)
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";


            //remover delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType()
            .GetProperty("DataAtualizacao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataAtualizacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAtualizacao").IsModified = false;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

