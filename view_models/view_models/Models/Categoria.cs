using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace view_models.Models
{
    public class Categoria
    {
        public Categoria()
        {
            Produtos = new HashSet<Produto>();
        }

        public int CategoriaId { get; set; }

        public string Nome { get; set; }

       public ICollection<Produto> Produtos { get; set; }
       

    }
}
