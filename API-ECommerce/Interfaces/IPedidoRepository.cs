using API_ECommerce.DTOs;
using API_ECommerce.Models;
using API_ECommerce.ViewModels;

namespace API_ECommerce.Interfaces;

public interface IPedidoRepository
{
    List<Pedido> ListarTodos();
    Pedido BuscarPorId(int id);
    void Cadastrar(Pedido pedido);
    void Atualizar(int id, Pedido pedido);
    void Deletar(int id);
}
