using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nodus.NodusArt.Domain.Models;
using System;

namespace Nodus.NodusArt.Data.Mapping
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(e => e.Descricao).IsRequired().HasColumnType("varchar(100)")
                .HasColumnName("Descricao");
            builder.Property(e => e.Observacao);

            builder.ToTable("Evento");
        }
    }
}

