namespace API_ECommerce.DTOs;

public class PagamentoDto
{
    public string StatusPagamento { get; set; } = null!;

    public string FormaPagamento { get; set; } = null!;

    public DateTime DataPagamento { get; set; }

    public int IdPedido { get; set; }
}
