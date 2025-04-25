
namespace API_ECommerce.ViewModels;

public class PagamentoViewModel
{
    public int IdPagamento { get; set; }

    public string StatusPagamento { get; set; } = null!;

    public string FormaPagamento { get; set; } = null!;

    public DateTime DataPagamento { get; set; }

    public int IdPedido { get; set; }

}
