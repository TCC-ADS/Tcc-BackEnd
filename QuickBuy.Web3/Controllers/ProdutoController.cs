using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    /// <summary>
    /// Controller do produto
    /// </summary>
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        /// <summary>
        /// Metodo construtor
        /// </summary>
        /// <param name="produtoRepositorio"></param>
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        /// <summary>
        /// Obtem todos os produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/v1/Produto/GetAll")]
        public IActionResult ObterProdutos()
        {
            try
            {
                return Ok(_produtoRepositorio.ObterTodos());
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Obtem um produto pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("api/v1/Produto/GetId")]
        public IActionResult Get(int id)
        {
            try
            {
                var IdProduto = _produtoRepositorio.ObterPorId(id);
                return Ok(IdProduto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPost, Route("api/v1/Produto/Create")]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                _produtoRepositorio.Adicionar(produto);
                return Created("api/v1/Produto", produto);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpPut, Route("api/v1/Produto/Update")]
        public IActionResult AtualizarProduto([FromBody] Produto produto)
        {
            try
            {
                _produtoRepositorio.Atualizar(produto);
                return Created("api/v1/Produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deleta um produto
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        [HttpDelete, Route("api/v1/Produto/Delete")]
        public IActionResult RemoverProduto([FromBody]Produto produto)
        {
            try
            {
                _produtoRepositorio.Remover(produto);
                return Created("api/v1/Produto/Update", produto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
