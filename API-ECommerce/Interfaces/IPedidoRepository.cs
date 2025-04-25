using API_ECommerce.DTOs;
using API_ECommerce.Models;

namespace API_ECommerce.Interfaces;

public interface IPedidoRepository
{
    List<Pedido> ListarTodos();
    Pedido BuscarPorId(int id);
    void Cadastrar(PedidoDto pedido);
    void Atualizar(int id, Pedido pedidoDto);
    void Deletar(int id);
}
