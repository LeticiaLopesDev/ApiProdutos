using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProdutos.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        public int id { get; private set; }
        public string descricao { get; private set; }
        public decimal valor { get; private set; }
        public string? imagem { get; private set; }

        public Produto(string descricao, decimal valor, string? imagem)
        {
            this.descricao = descricao;
            this.valor = valor;
            this.imagem = imagem;
        }

        public Produto(int id, string descricao, decimal valor, string? imagem)
        {
            this.id = id;
            this.descricao = descricao;
            this.valor = valor;
            this.imagem = imagem;
        }
    }
}
