using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace view_models.Models.Maps
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");

            builder.HasKey(k => k.CategoriaId).HasName("pk_CategoriaId");

            builder.Property(p => p.Nome).HasColumnType("varchar(45)").IsRequired();

            //Falta props de naveg

        }
    }
}