using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.ViewModel
{
    public class ProdutoViewModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public IFormFile Imagem { get; set; }
    }
}
