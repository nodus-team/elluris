using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nodus.NodusArt.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nodus.NodusArt.Data.Mapping
{
    public class EventoPeriodoMap : IEntityTypeConfiguration<EventoPeriodo>
    {
        public void Configure(EntityTypeBuilder<EventoPeriodo> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.DataInicial).HasColumnName("DataInicial");
            builder.Property(p => p.DataFinal).HasColumnName("DataFinal");

            builder.ToTable("EstadoPaciente");
        }
    }
}
