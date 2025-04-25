using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;

namespace API_ECommerce.Repositories;

public class PedidoRepository : IPedidoRepository
{
    private readonly EcommerceContext _context;
    public PedidoRepository(EcommerceContext context)
    {
        _context = context;
    }
    public List<Pedido> ListarTodos()
    {
        return _context.Pedidos.ToList();
    }
    public Pedido BuscarPorId(int id)
    {
        throw new NotImplementedException();
    }
    public void Cadastrar(PedidoDto pedidoDto)
    {
        // 1. Cadastrar o pedido crio a variavel para guardar os dados do pedido

        var pedido = new Pedido
        {
            DataPedido = pedidoDto.DataPedido,
            Status = pedidoDto.Status,
            ValorTotal = pedidoDto.ValorTotal,
            IdCliente = pedidoDto.IdCliente
        };

        _context.Pedidos.Add(pedido);
        _context.SaveChanges();

        // 2. Cadastrar os ItensPedido
        // Para cada PRODUTO, eu crio um ItemPedido
        for (int i = 0; i < pedidoDto.Produtos.Count; i++)
        {
            var produto = _context.Produtos.Find(pedidoDto.Produtos[i]);

            var itemPedido = new ItemPedido
            {
                IdPedido = pedido.IdPedido,
                IdProduto = produto.IdProduto,
                Quantidade = 0
            };
                _context.ItemPedidos.Add(itemPedido);
                _context.SaveChanges();
        }
    }
    public void Atualizar(int id, Pedido pedido)
    {
        throw new NotImplementedException();
    }
    public void Deletar(int id)
    {
        throw new NotImplementedException();
    }
}
