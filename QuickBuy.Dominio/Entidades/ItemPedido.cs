using System;
using System.Collections.Generic;

namespace QuickBuy.Dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }

        internal static bool any()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
