using System;
using System.Collections.Generic;

namespace API_ECommerce.Models;

public partial class Pagamento
{
    public int IdPagamento { get; set; }

    public string StatusPagamento { get; set; } = null!;

    public string FormaPagamento { get; set; } = null!;

    public DateTime DataPagamento { get; set; }

    public int IdPedido { get; set; }

    //Por padrão o entityframework nos traz <Nome da tabela>Id, no caso criamos Id<Nome da tabela> (que é fora do padrão de nomenclatura)lá no banco de dados.
    public virtual Pedido? IdPedidoNavigation { get; set; } = null!;
}
