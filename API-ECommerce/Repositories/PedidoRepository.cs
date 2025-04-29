using API_ECommerce.Context;
using API_ECommerce.DTOs;
using API_ECommerce.Interfaces;
using API_ECommerce.Models;
using Microsoft.EntityFrameworkCore;

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
        return _context.Pedidos
            .Include(p => p.ItemPedidos)
            .ThenInclude(p => p.IdProdutoNavigation)
            .ToList();
    }
    public Pedido? BuscarPorId(int id)
    {
        return _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);
    }
    public void Cadastrar(Pedido pedido)
    {
        var pedidoNovo = new Pedido
        {
            DataPedido = pedido.DataPedido,
            Status = pedido.Status,
            ValorTotal = pedido.ValorTotal,
            IdCliente = pedido.IdCliente
        };

        _context.Pedidos.Add(pedidoNovo);
        _context.SaveChanges();

        for (int i = 0; i < pedidoNovo.Pedidos.Count; i++)
        {
            var produto = _context.Produtos.Find(pedidoNovo.Produtos[i]);

            var itemPedido = new ItemPedido
            {
                IdPedido = pedidoNovo.IdPedido,
                IdProduto = produto.IdProduto,
                Quantidade = 0
            };
                _context.ItemPedidos.Add(itemPedido);
                _context.SaveChanges();
        }
    }
    public void Atualizar(int id, Pedido pedido)
    {
        var pedidoAtual = _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);

        if(pedido == null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        pedido.Status = pedido.Status;
        pedido.IdCliente = pedido.IdCliente;
        pedido.ValorTotal = pedido.ValorTotal;
        pedido.DataPedido = pedido.DataPedido;

        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        var pedido = _context.Pedidos.FirstOrDefault(p => p.IdPedido == id);

        if (pedido == null)
        {
            throw new Exception("Pedido não encontrado.");
        }

        _context.Pedidos.Remove(pedido);

        _context.SaveChanges();
    }
}
