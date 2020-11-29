using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
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

        //[HttpGet]
        //public IActionResult Get(int id)
        //{
        //    try
        //    {
        //        int IdProduto = Convert.ToInt32(_produtoRepositorio.ObterPorId(id));
        //        return Ok(IdProduto);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.ToString());
        //    }
        //}

        [HttpPost]
        public IActionResult AdicionarProduto([FromBody] Produto produto)
        {
            try
            {
                _produtoRepositorio.Adicionar(produto);
                return Created("api/produto", produto);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        public IActionResult AtualizarProduto([FromBody] Produto produto)
        {
            try
            {
                _produtoRepositorio.Atualizar(produto);
                return Created("api/produto", produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
