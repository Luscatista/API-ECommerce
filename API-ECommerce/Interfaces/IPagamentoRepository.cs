using API_ECommerce.DTOs;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces;

public interface IPagamentoRepository
{
    List<Pagamento> ListarTodos();
    Pagamento BuscarPorId(int id);
    void Cadastrar(PagamentoDto pagamento);
    void Atualizar(int id, Pagamento pagamento);
    void Deletar(int id);
}
