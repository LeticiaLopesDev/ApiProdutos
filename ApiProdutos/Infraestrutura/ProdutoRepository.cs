using ApiProdutos.Models;

namespace ApiProdutos.Infraestrutura
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void Add(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return _context.Produtos.ToList();
        }

        public void Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null) 
            {                
                _context.Remove(produto);
                _context.SaveChanges();            
            }
        }

        public Produto? Get(int id)
        {
            return _context.Produtos.Find(id);
        }
    }
}
