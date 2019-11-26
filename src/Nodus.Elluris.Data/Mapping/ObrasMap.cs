

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nodus.Elluris.Domain.Models;

namespace Nodus.Elluris.Data.Mapping
{
    public class ObrasMap : IEntityTypeConfiguration<Obras>
    {
        public void Configure(EntityTypeBuilder<Obras> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(b => b.Descricao).HasColumnName("Descricao");
            builder.Property(o => o.Observacao).HasColumnName("Observacao");
            builder.Property(o => o.UrlFoto).HasColumnName("UrlFoto");

            builder.ToTable("Obras");
        }
    }
}
