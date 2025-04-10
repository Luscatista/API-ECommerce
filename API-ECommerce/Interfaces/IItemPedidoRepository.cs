using API_ECommerce.Models;

namespace API_ECommerce.Interfaces
{
    public interface IItemPedidoRepository
    {
        List<ItemPedido> ListarTodos();
        ItemPedido BuscarPorId(int id);
        void Cadastro(ItemPedido itemPedido);
        void Atualizar(int id, ItemPedido itemPedido);
        void Deletar(int id);
    }
}
