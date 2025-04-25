using API_ECommerce.DTOs;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces;

public interface IPagamentoRepository
{
    List<PagamentoViewModel> ListarTodos();
    PagamentoViewModel BuscarPorId(int id);
    void Cadastrar(PagamentoDto pagamento);
    void Atualizar(int id, PagamentoDto pagamento);
    void Deletar(int id);
}
