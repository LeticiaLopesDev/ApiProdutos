using ApiProdutos.Models;
using ApiProdutos.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add([FromForm]ProdutoViewModel produtoView)
        {
            var filePath = Path.Combine("Storage", produtoView.Imagem.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            produtoView.Imagem.CopyTo(fileStream);

            var produto = new Produto(produtoView.Descricao, produtoView.Valor, filePath);
            _produtoRepository.Add(produto);

            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _produtoRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("getall")]
        public IActionResult GetAll()
        {
            var produtos = _produtoRepository.GetAll();

            return Ok(produtos);
        }

        [HttpGet]
        [Route("{id}/image")]
        public IActionResult DownloadImage(int id)
        {
            var produto = _produtoRepository.Get(id);

            if (produto == null)
                return NotFound();
            else if (string.IsNullOrWhiteSpace(produto.imagem))
                return NotFound("Produto não tem imagem");

            var dataBytes = System.IO.File.ReadAllBytes(produto.imagem);
            return File(dataBytes, "image/png");
        }   
    }
}
