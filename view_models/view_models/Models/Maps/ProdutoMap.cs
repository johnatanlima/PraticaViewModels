using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace view_models.Models.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(k => k.ProdutoId).HasName("pk_ProdutoId");

            builder.Property(p => p.Nome).HasColumnType("varchar(45)").IsRequired();

            builder.Property(p => p.Preco).HasColumnType("decimal(9,2)").IsRequired();

            builder.Property(p => p.Email).HasColumnType("varchar(45)");
            //Falta props de naveg

        }
    }
}