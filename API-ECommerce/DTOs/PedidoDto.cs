using API_ECommerce.Models;
using System.Text.Json.Serialization;

namespace API_ECommerce.DTOs;

//recebo os dados do pedido e recebo os dados dos produtos comprados
public class PedidoDto
{
    public DateOnly DataPedido { get; set; }

    public string Status { get; set; } = null!;

    public decimal? ValorTotal { get; set; }

    public int IdCliente { get; set; }

    public List<int> Produtos { get; set; }

}
