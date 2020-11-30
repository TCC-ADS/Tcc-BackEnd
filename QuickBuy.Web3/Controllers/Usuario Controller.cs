using Microsoft.AspNetCore.Mvc;
using QuickBuy.Dominio.Contratos;
using QuickBuy.Dominio.Entidades;
using System;

namespace QuickBuy.Web.Controllers
{
    /// <summary>
    /// Controller do usuario
    /// </summary>
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        /// <summary>
        /// Metodo construtor
        /// </summary>
        /// <param name="usuarioRepositorio"></param>
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        /// <summary>
        /// Obtem todos os usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("api/v1/Usuario/GetAll")]
        public IActionResult ObterTodos()
        {
            try
            {
                return Ok(_usuarioRepositorio.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Obtem um usuario pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("api/v1/Usuario/GetId")]
        public IActionResult ObterId(int id)
        {
            try
            {
                var usuario = _usuarioRepositorio.ObterPorId(id);
                return Ok(usuario);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost, Route("api/v1/Usuaio/Create")]
        public IActionResult AdicionarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Adicionar(usuario);
                return Created("api/v1/Usuaio", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza informações do usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPut, Route("api/v1/Usuaio/Update")]
        public IActionResult AtualizarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Atualizar(usuario);
                return Created("api/v1/Usuario", usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpDelete, Route("api/v1/Usuaio/Delete")]
        public IActionResult DeletarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioRepositorio.Remover(usuario);
                return Created("api/v1/Usuaio/", usuario);
            }catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
