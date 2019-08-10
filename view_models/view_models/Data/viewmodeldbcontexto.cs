using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using view_models.Models.Maps;

namespace view_models.Models
{
    public class viewmodeldbcontexto : DbContext
    {
        public viewmodeldbcontexto(DbContextOptions<viewmodeldbcontexto> options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProdutoMap());
            builder.ApplyConfiguration(new CategoriaMap());
        } 
    }
}
