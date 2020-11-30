using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    /// <summary>
    /// Classe controller de pedido
    /// </summary>
    public class PedidoController : Controller
    {
        private readonly IPedidoRepositorio _pedidoRepositorio;

        /// <summary>
        /// Metodo construtor
        /// </summary>
        /// <param name="pedidoRepositorio"></param>
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        /// <summary>
        /// Obtem todos os pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/v1/Pedido/GetAll")]
        public IActionResult ObterProdutos()
        {
            try
            {
                return Ok(_pedidoRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Obtem um pedido pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("api/v1/Pedido/GetAId")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var pedido = _pedidoRepositorio.ObterPorId(id);
                return Ok(pedido);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        [HttpPost, Route("api/v1/Pedido/Create")]
        public IActionResult AdicionarPedido([FromBody] Pedido pedido)
        {
            try
            {
                _pedidoRepositorio.Adicionar(pedido);
                return Created("api/v1/Pedido", pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
