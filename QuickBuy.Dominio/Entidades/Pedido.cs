using QuickBuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuickBuy.Dominio.Entidades
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int FormaPagamentoId { get; set; }

        /// <summary>
        /// quando for entidade de navegação (objeto ou lista) precisar marcar como virtual
        /// </summary>
        public virtual FormaPagamento FormaPagamento { get; set; }

        /// <summary>
        ///     Pedido deve ter pelo menos um item de pedido
        ///     ou muitos itens de pedidos
        /// </summary>
        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

        public override void Validate()
        {
            LimparMensagensValidacao();

            if (!ItensPedidos.Any())
                AdicionarCritica("Critica - Pedido não pode ficar sem item de pedido");

            if (FormaPagamentoId == 0)
                AdicionarCritica("Critica - Não foi informado a forma de pagamento");
        }
    }
}
