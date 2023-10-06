namespace ApiProdutos.Models
{
    public interface IProdutoRepository
    {
        void Add(Produto produto);
        void Delete(int id);
        List<Produto> GetAll();
        Produto? Get(int id);
    }
}
