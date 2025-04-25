using API_ECommerce.Models;
using System.Text.Json.Serialization;

namespace API_ECommerce.ViewModels;

public class PedidoViewModel
{
    public int IdPedido { get; set; }

    public DateOnly DataPedido { get; set; }

    public string Status { get; set; } = null!;

    public decimal? ValorTotal { get; set; }

    public int IdCliente { get; set; }
}
