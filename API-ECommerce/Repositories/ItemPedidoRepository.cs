using API_ECommerce.Context;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories;

public class ItemPedidoRepository : IItemPedidoRepository
{
    private readonly EcommerceContext _context;
    public ItemPedidoRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<ItemPedido> ListarTodos()
    {
        return _context.ItemPedidos.ToList();
    }

    public ItemPedido BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
    public void Cadastro(ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }
    public void Atualizar(int id, ItemPedido itemPedido)
    {
        throw new NotImplementedException();
    }
    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
