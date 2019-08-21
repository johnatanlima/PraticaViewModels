using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace view_models.ViewModels
{
    public class CategoriaViewModel
    {
        [Display(Name = "Identificação Categoria")]
        public string CategoriaId {get; set;}
        public string Nome { get; set; }

        [Display(Name = "Produtos por Categoria")]
        [DataType(DataType.Currency)]
        public string QuantidadeProdutos { get; set; }

        [Display(Name = "Preço Total")]
        public decimal SomaProdutos {get; set;}
        
    }
}

