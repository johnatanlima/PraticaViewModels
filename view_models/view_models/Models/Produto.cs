using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace view_models.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        [EmailAddress]
        public string Email {get; set;}
        public int CategoriaId {get; set;}
        public Categoria Categoria { get; set; }

    }

}
