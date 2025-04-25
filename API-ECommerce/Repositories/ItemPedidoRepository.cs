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

    public ItemPedido? BuscarPorId(int id)
    {
        return _context.ItemPedidos.FirstOrDefault(i => i.IdPedido == id);
    }
    public void Cadastrar(ItemPedido itemPedido)
    {
        _context.ItemPedidos.Add(itemPedido);
        _context.SaveChanges();
    }
    public void Atualizar(int id, ItemPedido itemPedido)
    {
        var itemPedidoAtual = _context.ItemPedidos.FirstOrDefault(i => i.IdItemPedido == id);
        if(itemPedidoAtual == null)
        {
            throw new Exception("ItemPedido não encontrado.");    
        }

        itemPedidoAtual.IdPedido = itemPedido.IdPedido;
        itemPedidoAtual.IdProduto = itemPedido.IdProduto;
        itemPedidoAtual.Quantidade = itemPedido.Quantidade;

        _context.Add(itemPedidoAtual);
        _context.SaveChanges();

    }
    public void Deletar(int id)
    {
        var itemPedido = _context.ItemPedidos.Find(id);

        if (itemPedido == null)
        {
            throw new Exception();
        }

        _context.ItemPedidos.Remove(itemPedido);

        _context.SaveChanges();
    }
}
